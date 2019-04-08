using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ionautics.view;
using ionautics.io;
using ionautics.core;
using System.Reactive.Linq;

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
            f1.Text = unit.Parameters[20].value.ToString();
            t1.Text = unit.Parameters[21].value.ToString();
            n1.Text = unit.Parameters[22].value.ToString();

            f2.Text = unit.Parameters[23].value.ToString();
            t2.Text = unit.Parameters[24].value.ToString();
            n2.Text = unit.Parameters[25].value.ToString();

            f3.Text = unit.Parameters[26].value.ToString();
            t3.Text = unit.Parameters[27].value.ToString();
            n3.Text = unit.Parameters[28].value.ToString();

            f4.Text = unit.Parameters[29].value.ToString();
            t4.Text = unit.Parameters[30].value.ToString();
            n4.Text = unit.Parameters[31].value.ToString();

            f5.Text = unit.Parameters[32].value.ToString();
            t5.Text = unit.Parameters[33].value.ToString();
            n5.Text = unit.Parameters[34].value.ToString();

            f6.Text = unit.Parameters[35].value.ToString();
            t6.Text = unit.Parameters[36].value.ToString();
            n6.Text = unit.Parameters[37].value.ToString();

            f7.Text = unit.Parameters[38].value.ToString();
            t7.Text = unit.Parameters[39].value.ToString();
            n7.Text = unit.Parameters[40].value.ToString();

            f8.Text = unit.Parameters[41].value.ToString();
            t8.Text = unit.Parameters[42].value.ToString();
            n8.Text = unit.Parameters[43].value.ToString();
        }

        private void refreshDelay() {
            dFreq.Text = unit.Parameters[50].value.ToString();
            dt1.Text = unit.Parameters[51].value.ToString();

            dt2.Text = unit.Parameters[52].value.ToString();
            ddt2.Text = unit.Parameters[53].value.ToString();

             dt3.Text = unit.Parameters[54].value.ToString();
            ddt3.Text = unit.Parameters[55].value.ToString();

             dt4.Text = unit.Parameters[56].value.ToString();
            ddt4.Text = unit.Parameters[57].value.ToString();

             dt5.Text = unit.Parameters[58].value.ToString();
            ddt5.Text = unit.Parameters[59].value.ToString();

             dt6.Text = unit.Parameters[60].value.ToString();
            ddt6.Text = unit.Parameters[61].value.ToString();

             dt7.Text = unit.Parameters[62].value.ToString();
            ddt7.Text = unit.Parameters[63].value.ToString();

             dt8.Text = unit.Parameters[64].value.ToString();
            ddt8.Text = unit.Parameters[65].value.ToString();
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
    }
}
