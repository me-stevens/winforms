using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using BattlestarGalactica;

namespace Tests
{
    [TestClass()]
    public class TestUI
    {
        [TestMethod()]
        public void TestPrintSquadronDisplaysTotalCylons()
        {
            var fakeConsole = BuildFakeConsole();

            CylonRaider.Counter = 0;
            BuildUI().PrintSquadron(new Battleship[,] {
                { new CylonRaider(1, 0), new CylonRaider(2, 1) },
                { new CylonRaider(3, 1), new CylonRaider(4, 0) },
            });

            StringAssert.Contains(fakeConsole.ToString(), "4 cylons");
        }

        [TestMethod()]
        public void TestPrintSquadronDisplaysDeadAndAliveCylons()
        {
            var fakeConsole = BuildFakeConsole();

            BuildUI().PrintSquadron(new Battleship[,] {
                { new CylonRaider(1, 0), new CylonRaider(2, 1) },
                { new CylonRaider(3, 1), new CylonRaider(4, 0) },
            });

            string substring = string.Format(
                "\t  C \n\n" +
                "\tC   \n\n"
            );

            StringAssert.Contains(fakeConsole.ToString(), substring);
        }

        [TestMethod()]
        public void TestWelcomeVipersPrintsViperName()
        {
            var fakeConsole = BuildFakeConsole();

            BuildUI().WelcomeVipers(new Battleship[,] {
                { new Viper("pilot1", "warcry1"), new Viper("pilot2", "warcry2") },
            });

            StringAssert.Contains(fakeConsole.ToString(), "pilot1");
            StringAssert.Contains(fakeConsole.ToString(), "pilot2");
        }

        [TestMethod()]
        public void TestPrintRoundDisplaysRoundNumber()
        {
            var fakeConsole = BuildFakeConsole();
            BuildUI().PrintRound(2);
            StringAssert.Contains(fakeConsole.ToString(), "ROUND 2");
        }

        [TestMethod()]
        public void TestPrintShootSummaryDisplaysNameAndLife()
        {
            var fakeConsole = BuildFakeConsole();
            BuildUI().PrintShootSummary(new Battleship());
            StringAssert.Contains(fakeConsole.ToString(), Battleship.DEFAULT_NAME);
            StringAssert.Contains(fakeConsole.ToString(), Battleship.DEFAULT_LIFE.ToString());
        }

        [TestMethod()]
        public void TestPrintShootSummaryDisplaysRIPForDeadShips()
        {
            var fakeConsole = BuildFakeConsole();
            BuildUI().PrintShootSummary(new Battleship(0));
            StringAssert.Contains(fakeConsole.ToString(), "R. I. P. " + Battleship.DEFAULT_NAME);
        }

        [TestMethod()]
        public void TestPrintWarCryDisplaysPilotNameAndWarCry()
        {
            var fakeConsole = BuildFakeConsole();
            BuildUI().PrintWarCry(new Viper("name", "warcry"));
            StringAssert.Contains(fakeConsole.ToString(), "name");
            StringAssert.Contains(fakeConsole.ToString(), "warcry");
        }

        [TestMethod()]
        public void TestPrintSummaryDisplaysVipersNameAndLifeIgnoringDead()
        {
            var fakeConsole = BuildFakeConsole();
            BuildFakeInput("\n");

            BuildUI().PrintSummary(new Battleship[,] {
                {
                    new Viper("pilot1", "irrelevant", 20),
                    new Viper("pilot2", "irrelevant", 50),
                    new Viper("pilot3", "irrelevant", 0)
                },
            });
            StringAssert.Contains(fakeConsole.ToString(), "pilot1, life: 20");
            StringAssert.Contains(fakeConsole.ToString(), "pilot2, life: 50");
            Assert.IsFalse(fakeConsole.ToString().Contains("pilot3"));
        }

        [TestMethod()]
        public void TestPrintSummaryDisplaysCylonSurvivorCount()
        {
            var fakeConsole = BuildFakeConsole();
            BuildFakeInput("\n");

            CylonRaider.Counter = 2;
            BuildUI().PrintSummary(new Battleship[,] { });

            StringAssert.Contains(fakeConsole.ToString(), "2 raiders");
        }

        public UI BuildUI()
        {
            return new UI(new FakeSleepService());
        }

        public StringWriter BuildFakeConsole()
        {
            var fakeConsole = new StringWriter();
            Console.SetOut(fakeConsole);
            return fakeConsole;
        }

        public StringReader BuildFakeInput(string input)
        {
            var fakeInput = new StringReader(input);
            Console.SetIn(fakeInput);
            return fakeInput;
        }
    }
}
