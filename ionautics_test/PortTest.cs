using System;
using NUnit.Framework;
using Moq;
using System.IO.Ports;
using ionautics.io;

namespace ionautics_test
{
    [TestFixture()]
    public class TestPort
    {
        [Test()]
        public void TestMocking()
        {
            Mock<IPort> mock = new Mock<IPort>();
            mock.Setup(p => p.IsOpen()).Returns(true);

            Assert.True(mock.Object.IsOpen());
        }
    }
}
