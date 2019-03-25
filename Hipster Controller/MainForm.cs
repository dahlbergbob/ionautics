using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ionautics
{
    public partial class Controller : Form
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

            AddAgg("First");
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

            if(result == DialogResult.OK)
            {
                AddAgg(popup.TabNameText);
            }
        }

        private void AddAgg(string label)
        {
            var page = new TabPage(label);
            var control = new Hipster();
            control.Dock = DockStyle.Fill;
            control.CloseClick += tabClick;
            page.Controls.Add(control);
            page.ImageIndex = 0;
            tabControl1.TabPages.Add(page);
        }
    }
}
