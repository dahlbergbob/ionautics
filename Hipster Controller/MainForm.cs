using ionautics.core;
using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Reactive.Linq;
using System.Linq;
using ionautics.io;
using ionautics.view;

namespace ionautics
{
    public partial class Controller : Form, IObserver<bool>
    {
        public Controller()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine(SerialPort.GetPortNames());
            foreach(string name in SerialPort.GetPortNames())
            {
                Console.WriteLine("Name -> "+ name);
            }

            //AddAgg("First", 0);
            App.running
                .SubscribeOn(this)
                .Subscribe(this);
        }

        private void tabClick(object sender, EventArgs e)
        {
            Console.WriteLine("clicked " + sender);
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void AddAggButton_Click(object sender, EventArgs e)
        {
            var popup = new AddDialog();
            var result = popup.ShowDialog();

            if(result == DialogResult.OK) {
                var port = App.ports.GetPort(popup.PortName, popup.BaudRate);
                AddAgg(popup.TabNameText, popup.Address, port);
            }
        }

        private void AddAgg(string label, int address, IPort port)
        {
            
            //port.WriteLine("0@20:4/24");
            //Console.WriteLine(port.ReadLine());

            var agg = new Aggregate(label, port, address);
            var page = new TabPage(label);
            var control = new Hipster(agg);
            control.Dock = DockStyle.Fill;
            control.CloseClick += tabClick;
            page.Controls.Add(control);
            page.ImageIndex = 0;
            tabControl1.TabPages.Add(page);
            App.units.Add(agg);
        }

        private void runToggle_Click(object sender, EventArgs e)
        {
            if(App.IsRunning()) {
                App.Stop();
            }
            else {
                App.Start();
            }
        }

        public void OnNext(bool running) {
            if(running) {
                runToggle.Text = "Stop";
                disableWhileRunning();
            }
            else {
                runToggle.Text = "Run";
                enableWhileIdle();
            }
        }

        public void OnError(Exception error){
            throw new NotImplementedException();
        }

        public void OnCompleted(){
            throw new NotImplementedException();
        }

        private void disableWhileRunning() {
            /*
            var result = port.Write(new Command(0, 1, 1));
            Console.WriteLine(result);
            */
            foreach (TabPage tab in tabControl1.TabPages) {
                var hipsters = tab.Controls.OfType<Hipster>().First();
                hipsters.preventEditing();
            }
        }

        private void enableWhileIdle()
        {
            /*
            var result = port.Write(new Command(0,1,0));
            Console.WriteLine(result);
            */
            foreach (TabPage tab in tabControl1.TabPages) {
                var hipsters = tab.Controls.OfType<Hipster>().First();
                hipsters.permittEditing();
            }
        }
    }
}
