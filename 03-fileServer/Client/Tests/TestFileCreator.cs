using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Linq;

using Client;

namespace Tests
{
    [TestClass()]
    public class TestFileCreator
    {
        public FakeFileCreationService file;

        [TestMethod()]
        public void TestCreateCreatesFileInUniquePath()
        {
            BuildFileCreator().Create(1, "S");
            Assert.AreEqual(file.FullPath, @"directory\1_S_00000.txt");
        }

        [TestMethod()]
        public void TestCreatePrintsTheFilenameFromTheFullPath()
        {
            var fakeConsole = FakeConsole.BuildFakeConsole();
            BuildFileCreator().Create(2, "H");
            StringAssert.Contains(fakeConsole.ToString(), "called '2_H_00000.txt");
        }

        [TestMethod()]
        public void TestCreateIncreasesCounterIfFileExists()
        {
            BuildExistingFileCreator().Create(3, "L");
            Assert.AreEqual(file.FullPath, @"directory\3_L_00002.txt");
        }

        [TestMethod()]
        public void TestCreateResetsCounterWhenMaximumValueReached()
        {
            Stack stack = new Stack(new bool[] { false });

            foreach (var _ in Enumerable.Range(0, FileCreator.MAXIMUM_COUNTER + 1))
                stack.Push(true);

            BuildCreator(stack).Create(3, "L");
            Assert.AreEqual(file.FullPath, @"directory\3_L_00000.txt");
        }

        [TestMethod]
        public void TestCreatePrintsErrorIfExceptionThrown()
        {
            var fakeConsole = FakeConsole.BuildFakeConsole();

            FakeExceptionThrower file = new FakeExceptionThrower();
            (new FileCreator("directory", new UI(), file)).Create(3, "L");

            StringAssert.Contains(fakeConsole.ToString(), "Pirate Error");
        }

        public FileCreator BuildFileCreator()
        {
            return BuildCreator(new Stack(new bool[] { false }));
        }

        public FileCreator BuildExistingFileCreator()
        {
            return BuildCreator(new Stack(new bool[] { false, true, true }));
        }

        public FileCreator BuildCreator(Stack stack)
        {
            file = new FakeFileCreationService(stack);
            return new FileCreator("directory", new UI(), file);
        }

        public class FakeExceptionThrower : FileCreationService
        {
            override public void Create(string fullPath)
            {
                throw new Exception("Pirate Error");
            }
        }
    }
}
