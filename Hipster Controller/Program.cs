using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ionautics;

namespace Hipster_Controller
{
    static class Program
    {
        //static Thread reader;
        //static SerialPort port;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Controller());

            return;
            /*
            var ports = SerialPort.GetPortNames();
            foreach (string p in ports) {
                Console.WriteLine("Port -> "+ p);
            }
            //SerialPort port = new SerialPort();

            port = new SerialPort("COM8", 38400, Parity.None, 8, StopBits.One);
            port.Encoding = System.Text.Encoding.ASCII;
            port.NewLine = "\n";
            port.ReadTimeout = 5000;
            port.WriteTimeout = 5000;
            Console.WriteLine("Open");
            port.Open();
            Console.WriteLine("Port is open? "+ port.IsOpen);

            port.ErrorReceived += Port_ErrorReceived;

            //reader = new Thread(RunReader);
            //reader.Start();

            Console.WriteLine("Write");
            port.WriteLine("0@20:20/40");
            Console.WriteLine("Result -> " + port.ReadLine());
            port.WriteLine("0@2145?");

            Console.WriteLine("Result -> " + port.ReadLine());
            */           
        }

        /*
        private static void Port_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            Console.WriteLine("Data received - " + sender);
        }

        static void RunReader()
        {
            try
            {
                Console.WriteLine("Read");
                var res = port.ReadLine();
                Console.WriteLine("Result -> " + res);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error -> " + e);
            }
            finally
            {
                Console.WriteLine("Close");
                port.Close();
            }
        }
        */
    }
}
