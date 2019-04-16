using System;
using System.IO.Ports;

namespace ionautics.io {

    public class Port : IPort {

        private SerialPort _port;

        public string Name {
            get => _port.PortName;
            set => _port.PortName = value;
        }

        public int BaudRate {
            get => _port.BaudRate;
        }

        internal void updateBaudRate(int baudrate) {
            if(_port.IsOpen) {
                _port.Close();
            }
            _port.BaudRate = baudrate;
        }

        public Port(SerialPort port) {
            _port = port;
            _port.NewLine = "\n";
            _port.ReadTimeout = 500;
            _port.WriteTimeout = 500;
            _port.Encoding = System.Text.Encoding.ASCII;
        }

        public bool IsOpen() => _port.IsOpen;

        public Command Read(Command parameter) {
            return Operate(parameter.address, parameter.ToReadCommand());
        }

        public Command Write(Command values) {
            return Operate(values.address, values.ToWriteCommand());
        }

        private Command Operate(int address, string output) {
            try {
                _port.WriteLine(output);
                var result = _port.ReadLine();
                return Command.Parse(result);
            }
            catch (TimeoutException e) {
                // Add retry strategy?
                return HandleError(address, e);
            }
        }

        private Command HandleError(int address, TimeoutException e) {
            Command c = new Command(address, -1, -1) {
                error = true,
                message = e.Message
            };
            return c;
        }

        public bool Open() {
            Console.WriteLine("##### OPEN");
            _port.Open();
            return IsOpen();
        }

        public void Close() {
            _port.Close();
            Console.WriteLine("##### CLOSE");
        }
    }
}
