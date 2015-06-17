using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

using BattlestarGalactica;

namespace Tests
{
    [TestClass()]
    public class TestViper
    {
        [TestMethod()]
        public void TestCreateFleetReturnsArrayOfVipers()
        {
            Battleship[,] viperFleet = Viper.CreateFleet(
                new (string, string, int)[] {
                    ("viper1", "warcry1", 200),
                    ("viper2", "warcry2", 100),
                }
            );

            Assert.AreEqual(((Viper)viperFleet[0, 0]).Pilot, "viper1");
            Assert.AreEqual(((Viper)viperFleet[0, 1]).Pilot, "viper2");
        }

        [TestMethod()]
        public void TestViperSetsLifeToDefault()
        {
            Assert.AreEqual((new Viper("pilot", "warcry")).Life, Battleship.DEFAULT_LIFE);
        }

        [TestMethod()]
        public void TestViperIncreasesCounter()
        {
            int counter = Viper.Counter;
            new Viper("pilot", "warcry");
            Assert.AreEqual(Viper.Counter, counter + 1);
        }

        [TestMethod()]
        public void TestViperAllowsForCustomLife()
        {
            int customLife = Battleship.DEFAULT_LIFE + 1;
            Assert.AreEqual((new Viper("pilot", "warcry", customLife)).Life, customLife);
        }

        [TestMethod()]
        public void TestViperWithCustomLifeIncreasesCounter()
        {
            int counter = Viper.Counter;
            new Viper("pilot", "warcry", Battleship.DEFAULT_LIFE + 1);
            Assert.AreEqual(Viper.Counter, counter + 1);
        }

        [TestMethod()]
        public void TestReceiveDealsHITPOINTSAmountOfDamage()
        {
            Viper viper = new Viper("pilot", "warcry");
            viper.Receive();
            Assert.AreEqual(viper.Life, Battleship.DEFAULT_LIFE / Viper.HITPOINTS);
        }

        [TestMethod()]
        public void TestReceiveDecreasesCounterIfDead()
        {
            Viper viper = new Viper("pilot", "warcry");
            int counter = Viper.Counter;

            foreach (var _ in Enumerable.Range(0, 4))
                viper.Receive();

            Assert.AreEqual(Viper.Counter, counter - 1);
        }

        [TestMethod()]
        public void TestPrintableNameReturnsPilotName()
        {
            string name = "viper";
            Assert.AreEqual((new Viper(name, "warcry")).PrintableName(), name);
        }
    }
}
