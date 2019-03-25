using System;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Reactive.PlatformServices;
using System.Collections.Generic;
using ionautics.io;
using System.Threading;

namespace ionautics.core
{
    public class Runner
    {
        private IDisposable _disposable;
        private List<Unit> _units;

        public Runner()
        {
        }

        public void Start(List<Unit> activeUnits, IObserver<long> observer)
        {
            _disposable?.Dispose();
            _units = activeUnits;
            _disposable = Observable.Interval(TimeSpan.FromSeconds(1))
                .Do(i => Print("Running on"))
                .Do(i => Poll())
                .ObserveOn(CurrentThreadScheduler.Instance)
                .Subscribe(observer);
        }

        private void Print(string from) {
            Console.WriteLine(from +" -> "+ System.Threading.Thread.CurrentThread.Name);
        }

        private void Poll() {
            /*
            _units.ForEach( it =>
                it
            )
            */
        }

        public void Stop()
        {
            _disposable?.Dispose();
            _disposable = null;
        }
    }
}
