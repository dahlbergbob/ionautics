using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ionautics.io;
using ionautics.view;
using ionautics.core;
using System.Reactive.Linq;
using ionautics.units;
using System.Drawing;

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
            refreshInit();
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
            setValue(udcRead, unit.Parameters[30]);
            setValue(idcRead, unit.Parameters[31]);
            setValue(pavgRead, unit.Parameters[32]);
            setValue(ipkRead, unit.Parameters[33]);
            setValue(qpulseRead, unit.Parameters[34]);
            setValue(arcCountRead, unit.Parameters[18]);
            setValue(interlockRead, unit.Parameters[3]);
        }
        private void refreshInit() {
            fetchValue(udcWrite);
            fetchValue(idcWrite);
            fetchValue(pavgWrite);
            fetchValue(ipkWrite);
            fetchValue(qpulseWrite);
            fetchValue(prrWrite);
            fetchValue(pwWrite);
            fetchValue(larcWrite);
            fetchValue(dlarcWrite);
        }

        private void fetchValue(TextBox setpoint) {
            int.TryParse(setpoint.Tag.ToString(), out int id);
            unit.ReadVal(id);
            setValue(setpoint, unit.Parameters[id]);
        }

        private void setValue(TextBox txt, Parameter param) {
            if (param.error) {
                txt.BackColor = App.ERROR_COLOR; 
            }
            else {
                txt.BackColor = Color.White;
                txt.Text = param.value.ToString();
            }
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
            
        }

        private void setpointWrite_KeyUp(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) { 
                var textBox = (TextBox)sender;
                int pid = 0;
                var success = int.TryParse(textBox.Text, out int val);
                success = success && int.TryParse(textBox.Tag.ToString(), out pid);
                if (success) {
                    var result = unit.SetVal(pid, val);
                    textBox.Text = result.value.ToString();
                }
            }
        }
    }
}
