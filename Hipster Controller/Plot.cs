using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ionautics.core;
using System.Reactive.Linq;
using ionautics.io;
using ionautics.view;
using System.Reactive.Concurrency;
using System.Windows.Forms.DataVisualization.Charting;

namespace ionautics
{
    public partial class Plot : UserControl, IObserver<Aggregate>
    {
        DataTable source = new DataTable();
        IDisposable disposable;

        public Plot() {
            InitializeComponent();


            source.Columns.Add("Average Voltage", typeof(int));
            source.Columns.Add("Average Current", typeof(int));
            chart1.DataSource = source;
            chart1.Series["Series1"].XValueMember = "Average Voltage";
            chart1.Series["Series1"].YValueMembers = "Average Current";
            chart1.Series["Series1"].ChartType = SeriesChartType.Line;
            App.updaterObservable
                .OfType<List<Aggregate>>()
                .Select(l => l.First())
                .ObserveOn(this)
                .Subscribe(this);
        }

        public void OnNext(Aggregate unit) {
            source.Rows.Add(unit.Parameters[30].value, unit.Parameters[31].value);
        }

        public void OnCompleted() {
            throw new NotImplementedException();
        }

        public void OnError(Exception error) {
            throw new NotImplementedException();
        }
    }
}
