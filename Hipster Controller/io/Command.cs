using System;
namespace ionautics.io
{
    public struct Command
    {
        public int address, parameter, value;
        public bool error;
        public string message;

        public Command(int address, int parameter, int value) {
            error = false;
            message = "";
            this.address = address;
            this.parameter = parameter;
            this.value = value;
        }

        public string ToReadCommand() => $"{address}@{parameter}?";

        public string ToWriteCommand()
        {
            int checksum = parameter + value;
            return $"{address}@{parameter}:{value}/{checksum}";
        }

        public static Command Parse(string result)
        {
            var c = new Command();

            c.error = result.Contains("!") ? true : false;
            if(c.error)
            {
                c.address = int.Parse(result.Substring(0, result.IndexOf('!')));
                c.parameter = 0;
                c.value = 0;
                c.message = result.Substring(result.IndexOf('!')+1);
            }
            else
            {
                var atIndex = result.IndexOf('@');
                var eqIndex = result.IndexOf('=');
                var slIndex = result.IndexOf('/');
                var a = result.Substring(0, atIndex);
                var p = result.Substring(atIndex+1, eqIndex-(atIndex+1));
                var v = result.Substring(eqIndex+1, slIndex-(eqIndex+1));

                c.address = int.Parse(a);
                c.parameter = int.Parse(p);
                c.value = int.Parse(v);
            }
            return c;
        }
    }
}
