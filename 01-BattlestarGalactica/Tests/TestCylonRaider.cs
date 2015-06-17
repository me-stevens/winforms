using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Linq;

using BattlestarGalactica;

namespace Tests
{
    [TestClass()]
    public class TestCylonRaider
    {
        [TestMethod()]
        public void TestCreateSquadronReturns2DArrayOfCylons()
        {
            int rows = 2, cols = 1;
            Battleship[,] cylonSquadron = CylonRaider.CreateSquadron(rows, cols);

            Assert.AreEqual(cylonSquadron.GetLength(0), rows);
            Assert.AreEqual(cylonSquadron.GetLength(1), cols);
        }

        [TestMethod()]
        public void TestCreateSquadronSetsCylonsLifeRandomly()
        {
            Stack randomLives = new Stack(new int[] { 70, 60 });
            Battleship[,] cylonSquadron = CylonRaider.CreateSquadron(1, 2, new FakeRandomGenerator(randomLives));

            Assert.AreEqual(cylonSquadron[0, 0].Life, 60);
            Assert.AreEqual(cylonSquadron[0, 1].Life, 70);
        }

        [TestMethod()]
        public void TestCylonRaiderSetsLifeToDefault()
        {
            Assert.AreEqual((new CylonRaider(1)).Life, CylonRaider.DEFAULT_LIFE);
        }

        [TestMethod()]
        public void TestCylonRaiderIncreasesCounter()
        {
            int counter = CylonRaider.Counter;
            new CylonRaider(1);
            Assert.AreEqual(CylonRaider.Counter, counter + 1);
        }

        [TestMethod()]
        public void TestCylonRaiderAllowsForCustomLife()
        {
            int customLife = CylonRaider.DEFAULT_LIFE + 1;
            Assert.AreEqual((new CylonRaider(1, customLife)).Life, customLife);
        }

        [TestMethod()]
        public void TestCylonRaiderWithCustomLifeIncreasesCounter()
        {
            int counter = CylonRaider.Counter;
            new CylonRaider(1, Battleship.DEFAULT_LIFE + 1);
            Assert.AreEqual(CylonRaider.Counter, counter + 1);
        }

        [TestMethod()]
        public void TestReceiveDealsHITPOINTSAmountOfDamage()
        {
            CylonRaider cylon = new CylonRaider(1);
            cylon.Receive();
            Assert.AreEqual(cylon.Life, CylonRaider.DEFAULT_LIFE / CylonRaider.HITPOINTS);
        }

        [TestMethod()]
        public void TestReceiveDecreasesCounterIfDead()
        {
            CylonRaider cylon = new CylonRaider(1);
            int counter = CylonRaider.Counter;

            foreach (var _ in Enumerable.Range(0, 2))
                cylon.Receive();

            Assert.AreEqual(CylonRaider.Counter, counter - 1);
        }

        [TestMethod()]
        public void TestPrintableNameReturnsCylonID()
        {
            Assert.AreEqual((new CylonRaider(1)).PrintableName(), "Cylon 1");
        }
    }
}
