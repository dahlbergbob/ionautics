using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ionautics.view;
using ionautics.io;
using ionautics.core;
using System.Reactive.Linq;
using System.Drawing;
using ionautics.units;

namespace ionautics
{
    public partial class Sync : UserControl, IRunningControl, ICloseable
    {
        public event EventHandler CloseClick;
        private Unit unit;

        public Sync(Unit agg){
            unit = agg;
            unit.IsActive = agg.IsActive;
            InitializeComponent();
            refreshBurst();
            refreshDelay();
            activeToggle.Checked = unit.IsActive;
            App.updaterObservable
                .Select(l => l.Contains(unit))
                .ObserveOn(this)
                .Subscribe(active => refresh(active));
        }

        private void Sync_Load(object sender, EventArgs e) {
            loopModeCombo.SelectedIndex = 0;
        }

        public Unit getUnit() => unit;

        private void refresh(bool active) {

            if(!active) {
                activeToggle.Checked = unit.IsActive;
                return;
            }

            if (unit.Parameters[2].value == 0) {
                refreshBurst();
            }
            else if (unit.Parameters[2].value == 1) {
                refreshDelay();
            }
        }

        private void refreshBurst() {
            setValue(f1, unit.Parameters[20]);
            setValue(t1, unit.Parameters[21]);
            setValue(n1, unit.Parameters[22]);

            setValue(f2, unit.Parameters[23]);
            setValue(t2, unit.Parameters[24]);
            setValue(n2, unit.Parameters[25]);

            setValue(f3, unit.Parameters[26]);
            setValue(t3, unit.Parameters[27]);
            setValue(n3, unit.Parameters[28]);

            setValue(f4, unit.Parameters[29]);
            setValue(t4, unit.Parameters[30]);
            setValue(n4, unit.Parameters[31]);

            setValue(f5, unit.Parameters[32]);
            setValue(t5, unit.Parameters[33]);
            setValue(n5, unit.Parameters[34]);

            setValue(f6, unit.Parameters[35]);
            setValue(t6, unit.Parameters[36]);
            setValue(n6, unit.Parameters[37]);

            setValue(f7, unit.Parameters[38]);
            setValue(t7, unit.Parameters[39]);
            setValue(n7, unit.Parameters[40]);

            setValue(f8, unit.Parameters[41]);
            setValue(t8, unit.Parameters[42]);
            setValue(n8, unit.Parameters[43]);
        }

        private void refreshDelay() {
            setValue(dFreq, unit.Parameters[50]);
            setValue(dt1, unit.Parameters[51]);

            setValue(dt2, unit.Parameters[52]);
            setValue(ddt2, unit.Parameters[53]);

            setValue(dt3, unit.Parameters[54]);
            setValue(ddt3, unit.Parameters[55]);

            setValue(dt4, unit.Parameters[56]);
            setValue(ddt4, unit.Parameters[57]);

            setValue(dt5, unit.Parameters[58]);
            setValue(ddt5, unit.Parameters[59]);

            setValue(dt6, unit.Parameters[60]);
            setValue(ddt6, unit.Parameters[61]);

            setValue(dt7, unit.Parameters[62]);
            setValue(ddt7, unit.Parameters[63]);

            setValue(dt8, unit.Parameters[64]);
            setValue(ddt8, unit.Parameters[65]);
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

        private void closeButton_Click(object sender, EventArgs e) {
            CloseClick?.Invoke(sender, e);
        }

        public void permittEditing() {
            activeToggle.Checked = unit.IsActive;
            Enabled = true;
        }

        public void preventEditing() {
            Enabled = false;
        }

        private void activeToggle_CheckedChanged(object sender, EventArgs e) {
            unit.IsActive = activeToggle.Checked;
        }

        private void modeRadio1_CheckedChanged(object sender, EventArgs e) {
            var radio = (RadioButton)sender;
            var sync = (SyncAggregate)unit;
            var value = radio == modeRadio1 ? 0 : 1;
            if (radio.Checked && sync != null) {

                var result = unit.SetVal(2, value);
                if(result.error) {
                    App.LogError("Couldnt set mode on sync");
                    App.LogComError(result, unit.port, false);
                }
                else if(result.value == value) {
                    var mode = value == 0 ? "burst" : "delay";
                    sync.setMode(mode);
                    Console.WriteLine("Mode changed to "+ value +".");
                }
                else {
                    Console.WriteLine("Problem changing mode, reset.");
                }
            }
        }

        private void loopModeCombo_SelectedIndexChanged(object sender, EventArgs e) {
            var value = loopModeCombo.SelectedIndex;
            var result = unit.SetVal(3, value);
            if (result.error) {
                App.LogError("Couldnt set loop mode.");
                App.LogComError(result, unit.port, false);
            }
            else if (result.value == value) {
                Console.WriteLine("Loop mode changed to " + value + ".");
            }
            else {
                Console.WriteLine("Problem changing loop mode, reset.");
                loopModeCombo.SelectedIndexChanged -= loopModeCombo_SelectedIndexChanged;
                loopModeCombo.SelectedIndex = result.value;
                loopModeCombo.SelectedIndexChanged += loopModeCombo_SelectedIndexChanged;
            }
        }

        private void on_KeyUp(object sender, KeyEventArgs e) {
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
