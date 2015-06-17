namespace BattlestarGalactica
{
    public class Combat
    {
        public const int ROUND_BREAK = 5;
        public const int ROUND_TOTAL = 20;

        private UI ui;

        public Combat(UI ui)
        {
            this.ui = ui;
        }

        public void Run(Battleship[,] cylonSquadron, Battleship[,] viperFleet)
        {
            int round = 0;

            foreach (CylonRaider cylon in cylonSquadron)
            {
                round++;
                ui.PrintRound(round);

                if (cylon.Life > 0)
                {
                    ui.PrintShootSummary(cylon.Shoot(viperFleet));
                }

                if (Viper.Counter == 0)
                {
                    ui.PrintDefeat();
                    return;
                }

                foreach (Viper viper in viperFleet)
                {
                    if (viper.Life > 0)
                    {
                        ui.PrintWarCry(viper);
                        ui.PrintShootSummary(viper.Shoot(cylonSquadron));

                        if (CylonRaider.Counter == 0)
                        {
                            ui.PrintVictory();
                            return;
                        }
                    }
                }

                PromptForNextRounds(round, cylonSquadron);
            }

            ui.PrintSummary(viperFleet);
        }

        private void PromptForNextRounds(int round, Battleship[,] cylonSquadron)
        {
            ui.PrintSquadron(cylonSquadron);

            if (round % ROUND_BREAK == 0 && round % ROUND_TOTAL != 0)
            {
                ui.WaitForNext();
            }
        }
    }
}
