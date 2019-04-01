using System;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Collections.Generic;
using ionautics.io;
using System.Linq;

namespace ionautics.core
{
    public class Runner
    {
        private IDisposable _disposable;

        public Runner() {
        }

        public void Start(List<Unit> activeUnits, IObserver<List<Unit>> observer) {
            _disposable?.Dispose();
            _disposable = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(l => Poll(activeUnits))
                .Subscribe(observer);
        }

        private List<Unit> Poll(List<Unit> activeUnits) {
            Console.WriteLine("Poll -> " + activeUnits.Count());
            activeUnits.ForEach(unit => {
                unit.Measure();
            });
            return activeUnits;
        }

        public void Stop() {
            _disposable?.Dispose();
            _disposable = null;
        }
    }
}
