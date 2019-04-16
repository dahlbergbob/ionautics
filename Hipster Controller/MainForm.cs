using ionautics.core;
using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Reactive.Linq;
using System.Linq;
using ionautics.io;
using ionautics.view;
using System.IO;

namespace ionautics
{
    public partial class Controller : Form, IObserver<bool>
    {
        IDisposable runningDisposable;
        IDisposable unitsDisposable;
        IDisposable errorDisposable;
        public Controller() {
            InitializeComponent();
        }

        private void cleanup(object sender, FormClosingEventArgs e) {
            Console.WriteLine("#### Program cleanup start");
            if(App.IsRunning()) {
                App.Stop();
            }
            runningDisposable?.Dispose();
            unitsDisposable?.Dispose();
            errorDisposable?.Dispose();
            App.ports.cleanup();
            Console.WriteLine("#### Program cleanup done");
        }

        private void MainForm_Load(object sender, EventArgs e) {
            runningDisposable = App.running
                .ObserveOn(this)
                .Subscribe(this);

            unitsDisposable = App.unitCount
                .ObserveOn(this)
                .Subscribe(pair => {
                    runToggle.Enabled = pair.Item1 > 0;
                    activeTabs.Text = $"There are {pair.Item1} out of {pair.Item2} active units.";
                });

            errorDisposable = App.error
                .Skip(1)
                .ObserveOn(this)
                .Subscribe(msg => {
                    //MessageBox.Show(msg, "An Error Occured", MessageBoxButtons.OK);
                    Console.WriteLine("Error -> " + msg);
                });


            AddGraph();
            AddAgg("Sync", 0, App.ports.GetPort("", 0, false), false);
            AddAgg("Agg", 0, App.ports.GetPort("", 0, false), true);
            this.FormClosing += cleanup;
        }

        private void closeTabClick(object sender, EventArgs e) {
            var aggView = tabControl1.SelectedTab.Controls.OfType<IRunningControl>().FirstOrDefault();
            App.RemoveUnit(aggView.getUnit());
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void AddAggButton_Click(object sender, EventArgs e) {

            App.refreshPorts();
            var popup = new AddDialog();
            var result = popup.ShowDialog();

            if(result == DialogResult.OK) {
                var port = App.ports.GetPort(popup.PortName, popup.BaudRate, false);
                bool isHipster = popup.IsHipster;
                AddAgg(popup.TabNameText, popup.Address, port, isHipster);
            }
        }

        private void AddAgg(string label, int address, IPort port, bool isHipster)
        {
            Unit unit;
            if (isHipster) {
                unit = new HipsterAggregate(label, port, address);
            }
            else {
                unit = new SyncAggregate(label, port, address);
            }
            unit.IsActive = true;
            AddAgg(unit);
        }

        private void AddAgg(Unit unit) {
            var page = new TabPage(unit.tab);
            Control control;

            if (unit.type == UnitType.AGG) {
                control = new Hipster(unit);
            }
            else {
                control = new Sync(unit);
            }

            control.Dock = DockStyle.Fill;
            ((ICloseable)control).CloseClick += closeTabClick;
            page.Controls.Add(control);
            page.ImageIndex = 0;
            tabControl1.TabPages.Add(page);
            App.AddUnit(unit);
        }

        private void AddGraph() {
            var page = new TabPage("Graph");
            Control control = new Plot();
            control.Dock = DockStyle.Fill;
            page.Controls.Add(control);
            page.ImageIndex = 0;
            tabControl1.TabPages.Add(page);
        }

        private void runToggle_Click(object sender, EventArgs e) {
            if(App.IsRunning()) {
                App.Stop();
            }
            else {
                App.Start();
            }
        }

        public void OnNext(bool running) {
            if(running) {
                runToggle.Text = "Stop";
                disableWhileRunning();
            }
            else {
                runToggle.Text = "Run";
                enableWhileIdle();
            }
        }

        public void OnError(Exception error){
            throw new NotImplementedException();
        }

        public void OnCompleted(){
            throw new NotImplementedException();
        }

        private void disableWhileRunning() {

            foreach (TabPage tab in tabControl1.TabPages) {
                var unitControl = tab.Controls.OfType<IRunningControl>().FirstOrDefault();
                if (unitControl != null) {
                    unitControl.preventEditing();
                }
            }
        }

        private void enableWhileIdle() {

            foreach (TabPage tab in tabControl1.TabPages) {
                var unitControl = tab.Controls.OfType<IRunningControl>().FirstOrDefault();
                if (unitControl != null) {
                    unitControl.permittEditing();
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e) {
            var json = App.save();
            var path = saveTo();
            if(path != string.Empty) { 
                File.WriteAllText(path, json);
            }
        }

        private void openButton_Click(object sender, EventArgs e) {
            var d = openFile();
            if (d == string.Empty) { return; }

            var units = App.open(d);
            Console.WriteLine("Units -> " + units);

            // Remove all current tabs
            foreach(TabPage page in tabControl1.TabPages) {
                var aggView = page.Controls.OfType<IRunningControl>().FirstOrDefault();
                if (aggView != null) { 
                    App.RemoveUnit(aggView.getUnit());
                    tabControl1.TabPages.Remove(page);
                }
            }
            // Add new tabs
            units.ForEach( u => AddAgg(u) );
        }

        private string saveTo() {
            var filePath = string.Empty;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
                saveFileDialog.Filter = "json files (*.json)|*.json";
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    //Get the path of specified file
                    filePath = saveFileDialog.FileName;
                }
            }
            return filePath;
        }

        private string openFile() {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream)) {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            Console.WriteLine("Path -> "+ filePath);
            Console.WriteLine("Content -> "+ fileContent);
            return fileContent;
        }
    }
}
