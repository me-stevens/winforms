using System;

namespace BattlestarGalactica
{
    public class UI
    {
        public const int TYPE_SPEED = 10;
        public const string CYLON_ALIVE = "C ";
        public const string CYLON_DEAD = "  ";

        private SleepService sleeper;

        public UI() : this(new SleepService())
        {
        }

        public UI(SleepService sleeper)
        {
            this.sleeper = sleeper;
        }

        public void PrintHeader()
        {
            TypeWrite("\n----------------------------------\n");
            TypeWrite("\n        BATTLESTAR GALACTICA\n");
            TypeWrite("\n----------------------------------\n");
            sleeper.Sleep(30);
            TypeWrite("\nAttention! Cylon troops on sight!");
            TypeWrite("\nCondition 1 set throughout the fleet!");
            TypeWrite("\nGalactica's best pilots are sent to battle!\r\n");
        }

        public void PrintSquadron(Battleship[,] squadron)
        {
            Console.WriteLine("\n{0} cylons are coming at us!!", CylonRaider.Counter);
            Console.Write("\n\t");

            int col = 0;
            foreach (CylonRaider cylon in squadron)
            {
                if (cylon.Life <= 0)
                    Console.Write(CYLON_DEAD);
                else
                    Console.Write(CYLON_ALIVE);

                col++;
                if (col % squadron.GetLength(1) == 0)
                    Console.Write("\n\n\t");
            }
        }

        public void WelcomeVipers(Battleship[,] vipers)
        {
            Console.WriteLine();
            foreach (Viper viper in vipers)
            {
                Console.WriteLine("{0}, GO AHEAD!", viper.Pilot);
            }
        }

        public void WaitForStart()
        {
            Console.WriteLine("\nPress Enter to start shooting!");
            Console.ReadLine();
        }

        public void WaitForNext()
        {
            Console.Write("\nPress enter for 5 more turns ");
            Console.ReadLine();
        }

        public void PrintRound(int round)
        {
            Console.WriteLine("\n-----------------------");
            Console.WriteLine("\n\tROUND {0}", round);
            Console.WriteLine("\n-----------------------\n");
        }

        public void PrintShootSummary(Battleship ship)
        {
            Console.WriteLine("Hit!! {0}'s life reduced to {1}", ship.PrintableName(), ship.Life);
            if (ship.IsDead())
            {
                Console.WriteLine("\tR. I. P. {0}", ship.PrintableName());
            }
        }

        public void PrintDefeat()
        {
            Console.WriteLine("\n----------------------------------------");
            TypeWrite("\n  Cylons win, Human race is wiped out\n\tof the galaxy.\n");
            Console.WriteLine("\n----------------------------------------");
        }

        public void PrintVictory()
        {
            Console.WriteLine("\n----------------------------------------");
            TypeWrite("\n  Humans win, Cylons are wiped out\n\tof the galaxy  ...FOR NOW.\n");
            Console.WriteLine("\n----------------------------------------");
        }

        public void PrintWarCry(Viper viper)
        {
            Console.WriteLine("\n" + viper.Pilot + ": " + viper.PilotWarCry);
        }

        public void PrintSummary(Battleship[,] vipers)
        {
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("\n\nVIPER SURVIVORS:\n");

            foreach (Viper viper in vipers)
                if (viper.Life > 0)
                    Console.WriteLine("   {0}, life: {1}", viper.Pilot, viper.Life);

            Console.WriteLine("\n\nCYLON SURVIVORS:\n");
            Console.WriteLine("   " + CylonRaider.Counter + " raiders.");

            TypeWrite("\n\n\tWe'll live to see another day.\n");
            Console.ReadLine();
        }

        private void TypeWrite(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                sleeper.Sleep(TYPE_SPEED);
            }
        }
    }
}
