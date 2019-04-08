using System;
using System.Collections.Generic;
using System.Linq;
using ionautics.core;
using ionautics.units;

namespace ionautics.io
{
    public enum UnitType {
        AGG = 0, SYNC = 1
    }

    public abstract class Unit
    {
        public event EventHandler Update;
        public IPort port;
        internal string tab;
        public int address;
        internal Dictionary<int,Parameter> Parameters = new Dictionary<int, Parameter>();
        private bool _active = false;
        public abstract UnitType type { get; }
        protected int inactiveStart = -1;
        protected int inactiveEnd = -1;

        public bool IsActive {
            get => _active;
            set {
                _active = value;
                Update?.Invoke(this, EventArgs.Empty);
            }
        }

        public Unit(string tab, IPort port, int address) {
            this.port = port;
            this.tab = tab;
            this.address = address;
            IsActive = false;
        }

        public Command SetVal(int id, int value) {
            if (!port.IsOpen()) {
                port.Open();
            }
            var command = new Command(address, id, value);
            var result = port.Write(command);
            if (!result.error) {
                Parameters[id].value = result.value;
            }
            return result;
        }

        public void Measure() {
            if(!port.IsOpen()) {
                port.Open();
            }

            Parameters.Values.ToList().ForEach(p => {
                if (inactiveStart == -1 || p.id < inactiveStart || p.id > inactiveEnd) {
                    var result = port.Read(new Command(address, p.id, p.value));
                    if (!result.error) {
                        p.value = result.value;
                    }
                    else {
                        App.LogError(result.message);
                        IsActive = false;
                    }
                }
            });
        }
    }
}
