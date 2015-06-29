using Microsoft.VisualStudio.TestTools.UnitTesting;

using Client;

namespace Tests
{
    [TestClass()]
    public class TestUI
    {
        [TestMethod()]
        public void TestGetIDWorksWithCorrectInput()
        {
            int id = (new UI()).GetID(new string[] { "client.exe", "-i", "1" });
            Assert.AreEqual(id, 1);
        }

        [TestMethod()]
        public void TestGetIDPromptsForInputIfMissingArguments()
        {
            var fakeConsole = FakeConsole.BuildFakeConsole();
            FakeConsole.BuildFakeInput("client.exe -i 1\n");
            (new UI()).GetID(new string[] { "client.exe", "-i" });
            StringAssert.Contains(fakeConsole.ToString(), "type: client.exe -i <ID>");
        }

        [TestMethod()]
        public void TestGetIDProcessesCorrectInputIfMissingArguments()
        {
            FakeConsole.BuildFakeInput("client.exe -i 1\n");
            int id = (new UI()).GetID(new string[] { "client.exe", "-i" });
            Assert.AreEqual(id, 1);
        }

        [TestMethod()]
        public void TestGetIDPromptsForInputIfNotANumber()
        {
            var fakeConsole = FakeConsole.BuildFakeConsole();
            FakeConsole.BuildFakeInput("2\n");
            (new UI()).GetID(new string[] { "client.exe", "-i" , "notAnumber"});
            StringAssert.Contains(fakeConsole.ToString(), "Retype number");
        }

        [TestMethod()]
        public void TestGetIDProcessesCorrectInputIfNumberIsTyped()
        {
            FakeConsole.BuildFakeInput("2\n");
            int id = (new UI()).GetID(new string[] { "client.exe", "-i", "notAnumber" });
            Assert.AreEqual(id, 2);
        }

        [TestMethod()]
        public void TestGetIDPromptsForInputIfNegativeNumber()
        {
            var fakeConsole = FakeConsole.BuildFakeConsole();
            FakeConsole.BuildFakeInput("2\n");
            (new UI()).GetID(new string[] { "client.exe", "-i" , "-5"});
            StringAssert.Contains(fakeConsole.ToString(), "negative");
        }

        [TestMethod()]
        public void TestGetIDProcessesCorrectInputIfPositiveNumberIsTyped()
        {
            FakeConsole.BuildFakeInput("3\n");
            int id = (new UI()).GetID(new string[] { "client.exe", "-i", "-7" });
            Assert.AreEqual(id, 3);
        }

        [TestMethod()]
        public void TestReadCommandEnsuresPermittedCommands()
        {
            FakeConsole.BuildFakeInput("S\n");
            Assert.AreEqual((new UI()).ReadCommand(), "S");

            FakeConsole.BuildFakeInput("H\n");
            Assert.AreEqual((new UI()).ReadCommand(), "H");

            FakeConsole.BuildFakeInput("L\n");
            Assert.AreEqual((new UI()).ReadCommand(), "L");
        }

        [TestMethod()]
        public void TestReadCommandPromptsUntilPermittedCommand()
        {
            var fakeConsole = FakeConsole.BuildFakeConsole();
            FakeConsole.BuildFakeInput("Invalid\nS\n");
            (new UI()).ReadCommand();
            StringAssert.Contains(fakeConsole.ToString(), "Please choose S, H or L");
        }

        [TestMethod()]
        public void TestReadCommandPrintsBackValidCommand()
        {
            var fakeConsole = FakeConsole.BuildFakeConsole();
            FakeConsole.BuildFakeInput("Invalid\nS\n");
            (new UI()).ReadCommand();
            StringAssert.Contains(fakeConsole.ToString(), "ye chose: S");
        }

        [TestMethod()]
        public void TestReadCommandReturnsValidCommandAfterFailure()
        {
            FakeConsole.BuildFakeInput("Invalid\nS\n");
            Assert.AreEqual((new UI()).ReadCommand(), "S");
        }

        [TestMethod()]
        public void TestPrintFilenameIncludesFilename()
        {
            var fakeConsole = FakeConsole.BuildFakeConsole();
            (new UI()).PrintFilename("name");
            StringAssert.Contains(fakeConsole.ToString(), "called 'name'.");
        }

        [TestMethod()]
        public void TestPromptToContinueIsTrueIfPositiveAnswerIgnoringCase()
        {
            FakeConsole.BuildFakeInput("AYE\n");
            Assert.IsTrue((new UI()).PromptToContinue());
        }

        [TestMethod()]
        public void TestPromptToContinueIsFalseIfNegativeAnswerIgnoringCase()
        {
            FakeConsole.BuildFakeInput("NoPe\n");
            Assert.IsFalse((new UI()).PromptToContinue());
        }

        [TestMethod()]
        public void TestPromptToContinueKeepsAskingUntilValidAnswer()
        {
            var fakeConsole = FakeConsole.BuildFakeConsole();
            FakeConsole.BuildFakeInput("Invalid\naye\n");
            (new UI()).PromptToContinue();
            StringAssert.Contains(fakeConsole.ToString(), "Write 'aye'");
        }
    }
}
