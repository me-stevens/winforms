using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

using BattlestarGalactica;

namespace Tests
{
    [TestClass()]
    public class TestBattleship
    {
        [TestMethod()]
        public void TestBattleshipSetsLifeToDefault()
        {
            Assert.AreEqual((new Battleship()).Life, Battleship.DEFAULT_LIFE);
        }

        [TestMethod()]
        public void TestBattleshipAllowsForCustomLife()
        {
            int customLife = Battleship.DEFAULT_LIFE + 1;
            Assert.AreEqual((new Battleship(customLife)).Life, customLife);
        }

        [TestMethod()]
        public void TestIsDeadDetectsDeadShips()
        {
            Assert.IsTrue((new Battleship(0)).IsDead());
        }

        [TestMethod()]
        public void TestIsDeadDetectsNonDeadShips()
        {
            Assert.IsFalse((new Battleship()).IsDead());
        }

        [TestMethod()]
        public void TestShootReturnsRandomAliveShip()
        {
            int row = 0, col = 1;
            Stack coordinates = new Stack(new int[] { col, row });

            Battleship shooter = new Battleship(5, new FakeRandomGenerator(coordinates));
            Battleship[,] targets = { { new Battleship(0), new Battleship(1) } };

            Assert.AreEqual(shooter.Shoot(targets), targets[row, col]);
        }

        [TestMethod()]
        public void TestShootKeepsTryingUntilAliveShipIsFound()
        {
            int deadRow = 0, deadCol = 0, liveRow = 0, liveCol = 1;
            Stack coordinates = new Stack(new int[] { liveCol, liveRow, deadCol, deadRow });

            Battleship shooter = new Battleship(5, new FakeRandomGenerator(coordinates));
            Battleship[,] targets = { { new Battleship(0), new Battleship(1) } };

            Assert.AreEqual(shooter.Shoot(targets), targets[liveRow, liveCol]);
        }

        [TestMethod()]
        public void TestShootMakesTheTargetReceiveDamage()
        {
            int row = 0, col = 1;
            Stack coordinates = new Stack(new int[] {col, row });

            Battleship shooter = new Battleship(5, new FakeRandomGenerator(coordinates));
            Battleship target = new CustomBattleship();
            Battleship[,] targets = { { new Battleship(0), target } };

            shooter.Shoot(targets);

            Assert.IsTrue(target.IsDead());
        }

        [TestMethod()]
        public void TestPrintableNameReturnsName()
        {
            Assert.AreEqual((new Battleship()).PrintableName(), Battleship.DEFAULT_NAME);
        }

        public class CustomBattleship : Battleship
        {
            override public void Receive()
            {
                Life = 0;
            }
        }
    }
}
