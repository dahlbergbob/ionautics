using ionautics.io;

namespace ionautics_test {

    public class PortMock : IPort {

        private bool _open = false;

        public bool IsOpen() => _open;

        public Command Read(Command parameter) {
            return parameter;
        }

        public Command Write(Command values) {
            return values;
        }

        public bool Open() {
            _open = true;
            return true;
        }

        public void Close() => _open = false;
    }
}
