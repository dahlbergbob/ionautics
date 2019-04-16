using ionautics.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using Newtonsoft.Json;
using ionautics.view;
using System.Drawing;
using System.Text;
using System.IO;

namespace ionautics.core
{
    internal class PortProxy{
        public string Name { get; set; }
        public int BaudRate { get; set; }
    }
    internal class UnitProxy {
        public PortProxy port { get; set; }
        public int address { get; set; }
        public string header { get; set; }
        public bool IsActive { get; set; }
        public string type { get; set; }
    }

    public class App
    {
        private static readonly StringBuilder errorLog = new StringBuilder();
        private static readonly object syncLock = new object();

        public static readonly Color ERROR_COLOR = Color.FromArgb(255, 200, 200);

        private static BehaviorSubject<bool> _running = new BehaviorSubject<bool>(false);
        private static BehaviorSubject<Tuple<int, int>> _units
            = new BehaviorSubject<Tuple<int, int>>(new Tuple<int, int>(0, 0));

        public static IObservable<bool> running = _running.DistinctUntilChanged();
        public static IObservable<Tuple<int, int>> unitCount = _units.DistinctUntilChanged();

        private static List<Unit> units = new List<Unit>();
        public static bool IsRunning() => _running.Value;
        public static IObservable<List<Unit>> updaterObservable = new ReplaySubject<List<Unit>>();
        public static BehaviorSubject<string> error = new BehaviorSubject<string>("");

        private static Runner runner = new Runner();

        internal static void refreshPorts() {
            ports.refresh();
        }

        public static PortModule ports;

        private static EventHandler handler = new EventHandler((o, e) => updateUnits());

        public static string save() => JsonConvert.SerializeObject(units);

        public static List<Unit> open(string json) {
            var list = new List<Unit>();
            var data = JsonConvert.DeserializeObject<List<UnitProxy>>(json);
            data.ForEach(unit => {
                var port = mapPort(unit.port);
                if (unit.type == "SYNC") {
                    var u = new SyncAggregate(unit.header, port, unit.address);
                    u.IsActive = unit.IsActive;
                    list.Add(u);
                }
                else if (unit.type == "AGG") {
                    var u = new HipsterAggregate(unit.header, port, unit.address);
                    u.IsActive = unit.IsActive;
                    list.Add(u);
                }
            });

            return list;
        }

        private static IPort mapPort(PortProxy proxy) {
            var naive = ports.GetPort(proxy.Name, proxy.BaudRate, true);
            if(naive != null) {
                return naive;
            }

            // Try to map the port with wrong name
            Console.WriteLine("--##--##--##-- Error finding port!!!");
            Console.WriteLine("--##--##--##-- Error finding port!!!");
            return ports.GetPort("", 0, false);
        }

        public static void AddUnit(Unit unit) {
            units.Add(unit);
            unit.Update += handler;
            updateUnits();
        }

        public static void RemoveUnit(Unit unit) {
            if(unit != null) { 
                unit.Update -= handler;
                units.Remove(unit);
                updateUnits();
            }
        }

        private static void updateUnits() {
            var active = units.Where(u => u.IsActive).Count();
            _units.OnNext(Tuple.Create(active, units.Count));
        }

        public static void Start() {
            var active = units.Where(u => u.IsActive).ToList();
            if (active.Count() > 0) {
                active.ForEach(u => {
                    if(!u.port.IsOpen()) {
                        u.port.Open();
                    }
                });
                runner.Start(active, updaterObservable as IObserver<List<Unit>>);
                _running.OnNext(true);
            }
        }

        public static void Stop() {
            runner.Stop();
            _running.OnNext(false);
            units.Where(u => u.IsActive).ToList().ForEach(u => {
                if (u.port.IsOpen()){
                    u.port.Close();
                }
            });
            writeLog(errorLog.ToString());
            errorLog.Clear();
        }

        internal static void LogError(string message) {
            error.OnNext(message);
        }

        internal static void LogComError(Command result, IPort port, bool read) {
            //"port, address, param, read, errormsg"
            lock(syncLock) { 
                errorLog.AppendLine($"{port.Name}, {result.address}, {result.parameter}, {read}, {result.message}");
                if(errorLog.Length > 1000) {
                    writeLog(errorLog.ToString());
                    errorLog.Clear();
                }
            }
        }

        internal static void writeLog(string msg) {
            Console.Write(msg);
            using (StreamWriter w = File.AppendText("log.txt")) {
                w.Write(msg);
            }
        }
    }
}
