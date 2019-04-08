using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ionautics.io;
using ionautics.view;
using ionautics.core;
using System.Reactive.Linq;

namespace ionautics
{
    public partial class Hipster : UserControl, IRunningControl, ICloseable
    {
        public event EventHandler CloseClick;
        private Unit unit;

        public Hipster(Unit agg) {
            unit = agg;
            unit.IsActive = agg.IsActive;
            InitializeComponent();
            refresh(true);
            activeToggle.Checked = unit.IsActive;
            App.updaterObservable
                .Select(l => l.Contains(unit))
                .ObserveOn(this)
                .Subscribe(active => refresh(active));
        }
        
        public Unit getUnit() => unit;

        private void refresh(bool active) {
            if(!active) {
                activeToggle.Checked = unit.IsActive;
                return;
            }
            udcRead.Text = unit.Parameters[20].value.ToString();
            idcRead.Text = unit.Parameters[21].value.ToString();
            pavgRead.Text = unit.Parameters[22].value.ToString();
            ipkRead.Text = unit.Parameters[23].value.ToString();
            qpulseRead.Text = unit.Parameters[24].value.ToString();
            arcCountRead.Text = unit.Parameters[18].value.ToString();
            interlockRead.Text = unit.Parameters[3].value.ToString();
        }

        private void button1_Click(object sender, EventArgs e) {
            CloseClick?.Invoke(sender, e);
        }

        private void activeToggle_CheckedChanged(object sender, EventArgs e) {
            unit.IsActive = activeToggle.Checked;
        }

        public void permittEditing() {
            activeToggle.Checked = unit.IsActive;
            activeToggle.Enabled = true;
            button1.Enabled = true;
        }

        public void preventEditing() {
            activeToggle.Enabled = false;
            button1.Enabled = false;
        }

        private void setpointWrite_Leave(object sender, EventArgs e) {
            var textBox = (TextBox)sender;
            int pid = 0;
            var success = int.TryParse(textBox.Text, out int val);
            success = success && int.TryParse(textBox.Tag.ToString(), out pid);
            if(success) {
                var result = unit.SetVal(pid, val);
                textBox.Text = result.value.ToString();
            }
        }
    }
}
