using Microsoft.VisualStudio.TestTools.UnitTesting;

using Server;
using System.IO;

namespace Tests
{
    [TestClass()]
    public class TestUI
    {
        [TestMethod()]
        public void TestPrintStatsDisplaysStats()
        {
            var fakeConsole = FakeConsole.BuildFakeConsole();
            (new UI()).PrintStats("fullpath", WatcherChangeTypes.Changed, "name");

            StringAssert.Contains(fakeConsole.ToString(), "fullpath");
            StringAssert.Contains(fakeConsole.ToString(), "Change");
            StringAssert.Contains(fakeConsole.ToString(), "name");
        }

        [TestMethod()]
        public void TestDrawSCommandPrintsCounter()
        {
            var fakeConsole = FakeConsole.BuildFakeConsole();
            (new UI()).DrawSCommand("2");
            StringAssert.Contains(fakeConsole.ToString(), "2");
        }

        [TestMethod()]
        public void TestDrawHCommandPrintsCounter()
        {
            var fakeConsole = FakeConsole.BuildFakeConsole();
            (new UI()).DrawHCommand("5");
            StringAssert.Contains(fakeConsole.ToString(), "5");
        }

        [TestMethod()]
        public void TestDrawLCommandPrintsLineIfIdIsOne()
        {
            var fakeConsole = FakeConsole.BuildFakeConsole();
            (new UI()).DrawLCommand("1");
            StringAssert.Contains(fakeConsole.ToString(), "=~~-");
        }

        [TestMethod()]
        public void TestDrawLCommandPrintsMessageIfIdIsNotOne()
        {
            var fakeConsole = FakeConsole.BuildFakeConsole();
            (new UI()).DrawLCommand("2");

            StringAssert.Contains(fakeConsole.ToString(), "Yo Ho");
        }

        [TestMethod()]
        public void TestWaitForExitDisplaysPromptUntilValidAnswer()
        {
            var fakeConsole = FakeConsole.BuildFakeConsole();
            FakeConsole.BuildFakeInput("foo\nbar\nq\n");
            (new UI()).WaitForExit();
            StringAssert.Contains(fakeConsole.ToString(), "quit");
        }
    }
}
