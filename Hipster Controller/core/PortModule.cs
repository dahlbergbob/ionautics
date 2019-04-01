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
            for(int i = 0; i < numberOfFakes; i++) {
                var name = "COM" + (i+1);
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
            return GetPort(name, baudrate) == null;
        }

        internal IPort GetPort(string name, int baudrate) {
            var port = _ports.FirstOrDefault(p => p.Name == name && p.BaudRate == baudrate);
            return port == null ? _ports[0] : port;
        }
    }


}
