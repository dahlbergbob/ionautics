using System;
using System.Collections.Generic;
using System.Linq;
using ionautics.io;
using ionautics.units;

namespace ionautics.view
{
    public class SyncAggregate : Unit
    {
        private readonly List<Parameter> _parameters = new List<Parameter> {
            new Parameter(1, "Pulse On/Off", 1, 0, "Pulse", true, 0),
            new Parameter(2, "Burst/Delay Mode", 1, 0, "Mode", true, 0),
            new Parameter(3, "Loop mode", 3, 0, "Loop", true, 0),

            new Parameter(20, "Burst F1", 50, 4000, "Hz", true, 0),
            new Parameter(21, "Burst T1", 5, 200, "μs", true, 0),
            new Parameter(22, "Burst N1", 1, 1000000, "", true, 0),
            new Parameter(23, "Burst F2", 50, 4000, "Hz", true, 0),
            new Parameter(24, "Burst T2", 5, 200, "μs", true, 0),
            new Parameter(25, "Burst N2", 1, 1000000, "", true, 0),
            new Parameter(26, "Burst F3", 50, 4000, "Hz", true, 0),
            new Parameter(27, "Burst T3", 5, 200, "μs", true, 0),
            new Parameter(28, "Burst N3", 1, 1000000, "", true, 0),
            new Parameter(29, "Burst F4", 50, 4000, "Hz", true, 0),
            new Parameter(30, "Burst T4", 5, 200, "μs", true, 0),
            new Parameter(31, "Burst N4", 1, 1000000, "", true, 0),
            new Parameter(32, "Burst F5", 50, 4000, "Hz", true, 0),
            new Parameter(33, "Burst T5", 5, 200, "μs", true, 0),
            new Parameter(34, "Burst N5", 1, 1000000, "", true, 0),
            new Parameter(35, "Burst F6", 50, 4000, "Hz", true, 0),
            new Parameter(36, "Burst T6", 5, 200, "μs", true, 0),
            new Parameter(37, "Burst N6", 1, 1000000, "", true, 0),
            new Parameter(38, "Burst F7", 50, 4000, "Hz", true, 0),
            new Parameter(39, "Burst T7", 5, 200, "μs", true, 0),
            new Parameter(40, "Burst N7", 1, 1000000, "", true, 0),
            new Parameter(41, "Burst F8", 50, 4000, "Hz", true, 0),
            new Parameter(42, "Burst T8", 5, 200, "μs", true, 0),
            new Parameter(43, "Burst N8", 1, 1000000, "", true, 0),

            new Parameter(50, "Delay F", 50, 4000, "Hz", true, 0),
            new Parameter(51, "Delay T1", 5, 200, "μs", true, 0),
            new Parameter(52, "Delay T2", 5, 200, "μs", true, 0),
            new Parameter(53, "Delay ∆T2", 1, 200, "μs", true, 0),
            new Parameter(54, "Delay T3", 5, 200, "μs", true, 0),
            new Parameter(55, "Delay ∆T3", 1, 200, "μs", true, 0),
            new Parameter(56, "Delay T4", 5, 200, "μs", true, 0),
            new Parameter(57, "Delay ∆T4", 1, 200, "μs", true, 0),
            new Parameter(58, "Delay T5", 5, 200, "μs", true, 0),
            new Parameter(59, "Delay ∆T5", 1, 200, "μs", true, 0),
            new Parameter(60, "Delay T6", 5, 200, "μs", true, 0),
            new Parameter(61, "Delay ∆T6", 1, 200, "μs", true, 0),
            new Parameter(62, "Delay T7", 5, 200, "μs", true, 0),
            new Parameter(63, "Delay ∆T7", 1, 200, "μs", true, 0),
            new Parameter(64, "Delay T8", 5, 200, "μs", true, 0),
            new Parameter(65, "Delay ∆T8", 1, 200, "μs", true, 0),
        };
        
        public string header { get; }
        public override UnitType type => UnitType.SYNC;

        public SyncAggregate(string tab, IPort port, int address) : base(tab, port, address) {
            header = tab;
            Parameters = _parameters.ToDictionary(l => l.id, l => l);
        }

        public void setMode(string mode) {
            if (mode == "burst") {
                inactiveStart = 50;
                inactiveEnd = 65;
            }
            else if(mode == "delay") {
                inactiveStart = 20;
                inactiveEnd = 43;
            }
        }
    }

}
