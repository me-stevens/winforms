namespace BattlestarGalactica
{
    public enum Result { Tie, Defeat, Victory }

    public class Runner
    {
        public const int ROWS = 4;
        public const int COLUMNS = 5;

        public static void Main(string[] args)
        {
            R unner p = new Runner(); // To call the non-static methods
            UI ui = new UI();

            Battleship[,] cylonSquadron = CylonRaider.CreateSquadron(ROWS, COLUMNS);
            Battleship[,] viperFleet = Viper.CreateFleet(
                new (string, string, int)[] {
                    ("Starbuck", "DIIIIIEEEEE MUTHERFUCKAAAASS!!!", 200),
                    ("Apollo", "Target on sight, GO! GO! GO!!!", 100),
                    ("Katraine", "Take that, you bag of shit!!", 70)
              }
            );

            ui.PrintHeader();
            ui.PrintSquadron(cylonSquadron);
            ui.WelcomeVipers(viperFleet);
            ui.WaitForStart();
            p.Combat(cylonSquadron, viperFleet, ui);
        }

        private void Combat(Battleship[,] cylonSquadron, Battleship[,] viperFleet, UI ui)
        {
            (new Combat(ui)).Run(cylonSquadron, viperFleet);
        }
    }
}
