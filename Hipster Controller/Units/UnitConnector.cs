namespace ionautics.units {

public class UnitConnector {
        public int id { get; }
        public string port { get; }
        public string address { get; }
        public int baud { get; }
        public int dataBits { get; }
        //public Parity parity { get; }
        //public StopBits stopBits { get; }
        public string parity { get; }
        public string stopBits { get; }
        public string newLine { get; }

        public UnitConnector(
                int id, string port, string address, int baud, int dataBits,
                string parity, string stopBits, string newLine)
        {
            this.id = id;
            this.port = port;
            this.address = address;
            this.baud = baud;
            this.dataBits = dataBits;
            this.parity = parity;
            this.stopBits = stopBits;
            this.newLine = newLine;
        }
    }
}
