using ionautics.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Reactive.Linq;

namespace ionautics.core
{
    public class App
    {
        private static BehaviorSubject<bool> _running = new BehaviorSubject<bool>(false);
        public static IObservable<bool> running = _running.DistinctUntilChanged();
        public static List<Unit> units = new List<Unit>();
        public static bool IsRunning() => _running.Value;

        private static Runner runner = new Runner();
        //private static IObserver<List<Unit>> fetcher = new UnitObserver();
        public static IObservable<List<Unit>> updater = new ReplaySubject<List<Unit>>();

        public static PortModule ports;
       

        public static void Start() {
            if(units.Count > 0) {
                runner.Start(units.Where(u => u.IsActive).ToList(), updater as IObserver<List<Unit>>);
                _running.OnNext(true);
            }
        }

        public static void Stop() {
            runner.Stop();
            _running.OnNext(false);
        }

        internal static void LogError(string message) {
            throw new NotImplementedException();
        }

        public App()
        {
        }
    }

    /*
    internal class UnitObserver : IObserver<List<Unit>>
    {
        public void OnCompleted() {
        }

        public void OnError(Exception error) {
            throw new NotImplementedException();
        }

        public void OnNext(List<Unit> value) {
            throw new NotImplementedException();
        }
    }
    */
}
