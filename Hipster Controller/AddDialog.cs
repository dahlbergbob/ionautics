using ionautics.core;
using ionautics.io;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ionautics
{

    public partial class AddDialog : Form
    {
        private List<int> _bps = new List<int>() { 38400, 115200 };
        public string TabNameText { get; set; }
        public int BaudRate { get; set; }
        public int Address { get; set; }
        public bool IsHipster = true;
        public string PortName { get; set; }

        public AddDialog() {
            InitializeComponent();
        }

        private void AddDialog_Load(object sender, EventArgs e) {
            var names = App.ports.GetNames();
            if (names.Count() == 0) {
                MessageBox.Show("Couldn't find any connected ports.", "No Ports", MessageBoxButtons.OK);
                return;
            }
            foreach (string name in names) {
                portNameBox.Items.Add(name);
            }

            var bps = _bps.Select( v => new { Key = v.ToString("### ###"), Val = v}).ToList();
            bpsBox.ValueMember = "Val";
            bpsBox.DisplayMember = "Key";
            bpsBox.DataSource = bps;

            portNameBox.SelectedIndex = 0;
        }

        private void OkButton_Click(object sender, EventArgs e) {

            if (TabName.Text.Length == 0) {
                MessageBox.Show("You need to specify a tab name.", "No Tab Name", MessageBoxButtons.OK);
                return;
            }
            if (addressNumber.Text.Length == 0) {
                MessageBox.Show("You need to specify an address.", "No Address", MessageBoxButtons.OK);
                return;
            }

            var bps = _bps[bpsBox.SelectedIndex];
            var pname = portNameBox.SelectedItem.ToString();
            if(App.ports.needsUpdate(pname, bps)) {
                var result = MessageBox.Show(
                    "Do you want to change the BaudRate for port \"" + pname +"\" in the entire application?",
                    "Change Port Setting",
                    MessageBoxButtons.OKCancel
                );
                if (result == DialogResult.OK) {
                    App.ports.updatePort(pname, bps);
                }
                else return;
            }

            PortName = pname;
            DialogResult = DialogResult.OK;
            TabNameText = TabName.Text;
            BaudRate = _bps[bpsBox.SelectedIndex];
            Address = int.Parse(addressNumber.Text);
            Close();
        }

        private void addressNumber_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void radioSync_CheckedChanged(object sender, EventArgs e) {
            IsHipster = !radioSync.Checked;
        }

        private void radioHipster_CheckedChanged(object sender, EventArgs e) {
            IsHipster = radioHipster.Checked;
        }
    }
}
