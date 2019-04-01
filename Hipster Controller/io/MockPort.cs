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

        public Command Read(Command parameter) {
            parameter.value = rand.Next();
            return parameter;
        }

        public Command Write(Command values) {
            return values;
        }
    }
}
