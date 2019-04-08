using ionautics.io;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace ionautics.core
{
    public class PortModule {

        private readonly List<IPort> _ports = new List<IPort>();
        private bool serial = false;

        public PortModule() {
            foreach(string name in SerialPort.GetPortNames()) {
                var p = new Port(new SerialPort(name, 38400, Parity.None, 8, StopBits.One));
                _ports.Add(p);
            }
        }

        public PortModule(int numberOfFakes) {
            var rnd = new Random().Next(1,4);
            for(int i = 0; i < numberOfFakes; i++) {
                var name = "COM" + (i+rnd);
                var p = new MockPort(name, 38400);
                _ports.Add(p);
            }
        }

        public string[] GetNames() {
            return _ports.Select(p => p.Name).ToArray();
        }

        public void updatePort(string name, int baudrate) {
            var found = _ports.First(p => p.Name == name);
            if (found != null) {
                if(serial) {
                    ((SerialPort)found).PortName = name;
                    ((SerialPort)found).BaudRate = baudrate;
                }
                else {
                    ((MockPort)found).Name = name;
                }
            }
        }

        internal bool needsUpdate(string name, int baudrate) {
            return GetPort(name, baudrate, true) == null;
        }

        internal void refresh() {
            if (serial) {
                var current = SerialPort.GetPortNames();
                var stored = GetNames();
                if (current.Count() == stored.Count()) {
                    if (current.All(p => stored.Contains(p))) {
                        return;
                    }
                }
                App.LogError("We need to update our ports!");
            }
        }

        internal IPort GetPort(string name, int baudrate, bool allowNull) {
            var port = _ports.FirstOrDefault(p => p.Name == name && p.BaudRate == baudrate);
            if(allowNull) {
                return port;
            }
            return port ?? _ports[0];
        }
    }


}
