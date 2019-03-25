namespace ionautics.units {
    public class Parameter
    {
        public int id { get; }
        public string name { get; }
        public int max { get; }
        public int min { get; }
        public string unit { get; }
        public int value { get; set; }
        public bool writable { get; }

        public Parameter(int id, string name, int max, int min, string unit, bool writable, int value)
        {
            this.id = id;
            this.name = name;
            this.max = max;
            this.min = min;
            this.unit = unit;
            this.writable = writable;
            this.value = value;
        }
    }
}
