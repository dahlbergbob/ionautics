
using System;

namespace ionautics.io
{
    class MockPort : IPort
    {
        private Random rand = new Random();
        private bool open = false;
        public string Name { get; set; }
        public int BaudRate { get; set; }

        public MockPort(string name, int baudrate) {
            Name = name;
            BaudRate = baudrate;
        }

        public void Close() {
            open = false;
        }

        public bool IsOpen() => open;

        public bool Open() {
            open = true;
            return true;
        }

        private Command errorCmd(Command c, string message) {
            c.error = true;
            c.message = message;
            return c;
        }

        public Command Read(Command parameter) {
            if (parameter.parameter > 3) { 
                parameter.value = rand.Next(1000);
                if(parameter.value > 990) {
                    parameter = errorCmd(parameter, "Invalid Parameter");
                }
            }
            return parameter;
        }

        public Command Write(Command values) {
            var n = rand.Next(100);
            if (n == 23) {
                values = errorCmd(values, "Invalid Message");
            }
            return values;
        }
    }
}
