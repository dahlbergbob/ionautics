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

namespace Hipster_Controller
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

            var control = new Hipster();
            control.Dock = DockStyle.Fill;
            tabPage1.Controls.Add(control);
        }

        private void AddAggButton_Click(object sender, EventArgs e)
        {
            var popup = new AddDialog();
            var result = popup.ShowDialog();

            if(result == DialogResult.OK)
            {
                var page = new TabPage(popup.TabNameText);
                page.BackColor = Color.Aquamarine;
                tabControl1.TabPages.Add(page);
            }
        }

        private void AddAgg(string label)
        {
            var page = new TabPage(label);
            tabControl1.TabPages.Add(page);
        }
    }
}
