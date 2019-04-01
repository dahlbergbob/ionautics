using System;
using System.Collections.Generic;
using ionautics.io;
using ionautics.units;

namespace ionautics.view
{
    public class Aggregate : Unit
    {
        private readonly List<Parameter> _parameters = new List<Parameter> {
            new Parameter(1, "Pulse On/Off", 1, 0, "Pulse", true, 0),
            new Parameter(2, "Pulse Source", 1, 0, "Source", true, 0),
            new Parameter(3, "Interlock status", 1, 0, "Interlock", false, 0),
            new Parameter(4, "Temperature Monitor", 25, 70, "°C", false, 0),
            new Parameter(10, "Frequency of internal generator", 50, 10_000, "Hz", true, 0),
            new Parameter(11, "Pulsewidth of internal generator", 35, 10_000, "μs/10", true, 0),
            new Parameter(15, "Arc-limit current setting", 0, 150, "Amperes", true, 0),
            new Parameter(16, "Arc-limit current rate setting", 0, 200, "Amperes/μs", true, 0),
            new Parameter(17, "Arc cutback percentage", 0, 100, "% of V", true, 0),
            new Parameter(18, "Arc counter", 0, 65535, "arcs", false, 0),
            new Parameter(20, "Average voltage setpoint", 0, 1000, "V", true, 0),
            new Parameter(21, "Average current setpoint", 0, 1000, "mA", true, 0),
            new Parameter(22, "Average power setpoint", 0, 1000, "W", true, 0),
            new Parameter(23, "Peak current setpoint", 0, 150, "A", true, 0),
            new Parameter(24, "Pulse charge setpoint", 0, 3000, "μC", true, 0),
            new Parameter(30, "Average voltage value", 0, 1000, "V", false, 0),
            new Parameter(31, "Average current value", 0, 1000, "mA", false, 0),
            new Parameter(32, "Average power value", 0, 1000, "W", false, 0),
            new Parameter(33, "Peak current value", 0, 150, "A", false, 0),
            new Parameter(34, "Pulse charge value", 0, 3000, "μC", false, 0),
        };
        
        public string header { get; }

        public Aggregate(string tab, IPort port, int address) : base(tab, port, address) {
            header = tab;
            Parameters.AddRange(_parameters);
        }
    }

}
