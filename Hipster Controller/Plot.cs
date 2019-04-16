using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ionautics.core;
using System.Reactive.Linq;
using ionautics.view;
using System.Windows.Forms.DataVisualization.Charting;
using ionautics.units;

namespace ionautics
{
    public partial class Plot : UserControl, IObserver<List<HipsterAggregate>> {

        private long count = 0;

        public Plot() {
            InitializeComponent();

            App.updaterObservable
                .Select(l => l.OfType<HipsterAggregate>().ToList())
                .ObserveOn(this)
                .Subscribe(this);

            App.running
                .Subscribe(running => {
                    if(running) {
                        count = 0;
                        for(var i = 0; i < chart1.Series.Count; i++ ) {
                            chart1.Series[i].Points.Clear();
                        }
                    }
                });
        }

        public void OnNext(List<HipsterAggregate> units) {
            if(count == 0) {
                var unit = units[0];
                addSerie(unit.Parameters[30].name);
                addSerie(unit.Parameters[31].name);
                addSerie(unit.Parameters[32].name);
                addSerie(unit.Parameters[33].name);
                addSerie(unit.Parameters[34].name);
            }
            count++;
            units.ForEach( unit => {
                addPoint(unit.Parameters[30]);
                addPoint(unit.Parameters[31]);
                addPoint(unit.Parameters[32]);
                addPoint(unit.Parameters[33]);
                addPoint(unit.Parameters[34]);
            });
        }

        private void addSerie(String name) {
            if(chart1.Series.FindByName(name) == null) {
                var serie = new Series(name);
                serie.ChartType = SeriesChartType.Line;
                chart1.Series.Add(serie);
            }
        }

        private void addPoint(Parameter param) {
            chart1.Series[param.name].Points.AddXY(count, param.value);
        }

        public void OnCompleted() {
            throw new NotImplementedException();
        }

        public void OnError(Exception error) {
            throw new NotImplementedException();
        }
    }
}
