using System;
using System.IO.Ports;

namespace ionautics.io {

    public class Port : IPort {

        private SerialPort _port;

        public Port(SerialPort port) {
            _port = port;
            _port.NewLine = "\n";
            _port.ReadTimeout = 50;
            _port.WriteTimeout = 50;
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
            Command c;
            c.address = address;
            c.value = -1;
            c.parameter = -1;
            c.error = true;
            c.message = e.Message;
            return c;
        }

        public bool Open() {
            _port.Open();
            return IsOpen();
        }

        public void Close() {
            _port.Close();
        }
    }
}
