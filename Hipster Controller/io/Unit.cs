using System;
using System.Collections.Generic;
using ionautics.core;
using ionautics.units;

namespace ionautics.io
{
    public class Unit
    {
        private IPort port;
        private string tab;
        private int address;
        public List<Parameter> Parameters = new List<Parameter>();

        public bool IsActive { get; set; }

        public Unit(string tab, IPort port, int address) {
            this.port = port;
            this.tab = tab;
            this.address = address;
            IsActive = false;
        }

        public void Measure() {
            if(!port.IsOpen()) {
                port.Open();
            }
            Parameters.ForEach(p => {
                var result = port.Read(new Command(address, p.id, p.value));
                if (!result.error) {
                    p.value = result.value;
                }
                else {
                    App.LogError(result.message);
                }
            });
        }
    }
}
