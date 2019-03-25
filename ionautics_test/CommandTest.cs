using ionautics.io;
using NUnit.Framework;
using System;

namespace ionautics_test
{
    [TestFixture()]
    public class CommandTest
    {
        [Test()]
        public void TestCommandCreation()
        {
            Command cmd = new Command(0, 20, 7);
            Assert.AreEqual("0@20?", cmd.ToReadCommand());
            Assert.AreEqual("0@20:7/27", cmd.ToWriteCommand());
            Assert.False(cmd.error);
        }

        [Test()]
        public void TestParseValue()
        {
            Command cmd = Command.Parse("0@20=7/27");
            Assert.AreEqual(0, cmd.address);
            Assert.AreEqual(20, cmd.parameter);
            Assert.AreEqual(7, cmd.value);
            Assert.False(cmd.error);
        }

        [Test()]
        public void TestParseFailure()
        {
            var err = "Da fuzz";
            Command cmd = Command.Parse("1!"+err);
            Assert.AreEqual(1, cmd.address);
            Assert.AreEqual(0, cmd.parameter);
            Assert.AreEqual(0, cmd.value);
            Assert.AreEqual(err, cmd.message);
            Assert.True(cmd.error);
        }
    }
}
