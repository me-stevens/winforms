namespace BattlestarGalactica
{
    public class Viper : Battleship
    {
        public static Battleship[,] CreateFleet((string, string, int)[] viperOptions)
        {
            Battleship[,] vipers = new Viper[1, viperOptions.Length];

            for (int i = 0; i < viperOptions.Length; i++)
            {
                var (pilot, warcry, life) = viperOptions[i];
                vipers[0, i] = new Viper(pilot, warcry, life);
            }

            return vipers;
        }

        public static int Counter = 0;
        public const int HITPOINTS = 2;

        // Vipers may have many pilots
        public string Pilot
        {
            get;
            set;
        }

        public string PilotWarCry
        {
            get;
            set;
        }

        public Viper(string Pilot, string PilotWarCry) : this(Pilot, PilotWarCry, Battleship.DEFAULT_LIFE)
        {
        }

        public Viper(string Pilot, string PilotWarCry, int Life) : base(Life)
        {
            this.Pilot = Pilot;
            this.PilotWarCry = PilotWarCry;
            Counter++;
        }

        override public void Receive()
        {
            Life /= HITPOINTS;

            if (IsDead())
            {
                Counter--;
            }
        }

        override public string PrintableName()
        {
            return Pilot;
        }
    }
}
