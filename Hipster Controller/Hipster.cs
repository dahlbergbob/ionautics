using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ionautics.io;
using ionautics.view;
using ionautics.core;
using System.Reactive.Linq;
using System.Reactive.Concurrency;

namespace ionautics
{
    public partial class Hipster : UserControl, IRunningControl
    {
        public event EventHandler CloseClick;
        private Aggregate unit;
        private int tick = 0;

        public Hipster(Aggregate agg) {
            unit = agg;
            unit.IsActive = true;
            InitializeComponent();
            refresh();
            App.updater
                .Where(l => l.Contains(unit))
                .Select(list => list.Find(u => u == unit))
                .ObserveOn(this)
                .Subscribe( _ => refresh());
        }

        private void refresh() {
            udcRead.Text = unit.Parameters.Where(p => p.id == 20).First().value.ToString();
            idcRead.Text = unit.Parameters.Where(p => p.id == 21).First().value.ToString();
            pavgRead.Text = unit.Parameters.Where(p => p.id == 22).First().value.ToString();
            ipkRead.Text = unit.Parameters.Where(p => p.id == 23).First().value.ToString();
            qpulseRead.Text = unit.Parameters.Where(p => p.id == 24).First().value.ToString();
            arcCountRead.Text = unit.Parameters.Where(p => p.id == 18).First().value.ToString();
            interlockRead.Text = unit.Parameters.Where(p => p.id == 3).First().value.ToString();
        }

        private void button1_Click(object sender, EventArgs e) {
            CloseClick?.Invoke(sender, e);
        }

        private void activeToggle_CheckedChanged(object sender, EventArgs e) {
            unit.IsActive = activeToggle.Checked;
        }

        public void permittEditing() {
            activeToggle.Enabled = true;
            button1.Enabled = true;
        }

        public void preventEditing() {
            activeToggle.Enabled = false;
            button1.Enabled = false;
        }
    }
}
