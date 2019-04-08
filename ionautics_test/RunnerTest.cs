using System;
using System.Collections.Generic;
using System.Threading;
using ionautics.core;
using ionautics.io;

namespace ionautics_test
{
    /*
    [TestFixture()]
    public class RunnerTest : IObserver<long>
    {
        public List<Unit> units = new List<Unit> {
            new Unit(),
            new Unit(),
            new Unit(),
            new Unit(),
            new Unit()
        };

        [Test()]
        public void TestCommandCreation() {
            var runner = new Runner();
            runner.Start(units, this);
            Thread.Sleep(6000);
            runner.Stop();
            Assert.True(true);
        }

        private void Printer(long tick) {
            System.Console.WriteLine("Thread -> " + Thread.CurrentThread.Name);
        }


        public void OnCompleted() {
            System.Console.WriteLine("Complete");
        }

        public void OnError(Exception error) {
            System.Console.WriteLine("Error");
        }

        public void OnNext(long value) {
            Printer(0);
        }
    }
    */
}
