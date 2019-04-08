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
            var stillActive = activeUnits.Where(u => u.IsActive).ToList();
            Console.WriteLine("Poll -> " + stillActive.Count());
            stillActive.ForEach(unit => {
                unit.Measure();
            });
            return stillActive;
        }

        public void Stop() {
            _disposable?.Dispose();
            _disposable = null;
        }
    }
}
