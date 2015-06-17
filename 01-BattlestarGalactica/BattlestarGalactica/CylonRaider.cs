namespace BattlestarGalactica
{
    public class CylonRaider : Battleship
    {
        public static Battleship[,] CreateSquadron(int rows, int cols)
        {
            return CylonRaider.CreateSquadron(rows, cols, new RandomGenerator());
        }

        public static Battleship[,] CreateSquadron(int rows, int cols, RandomGenerator random)
        {
            Battleship[,] squadron = new CylonRaider[rows, cols];
            int id = 0;

            for (int i = 0; i < squadron.GetLength(0); i++)
            {
                for (int j = 0; j < squadron.GetLength(1); j++)
                {
                    squadron[i, j] = new CylonRaider(id, random.Next(50, 100));
                    id++;
                }
            }

            return squadron;
        }

        public static int Counter = 0;
        public new const int DEFAULT_LIFE = 5;
        public const int HITPOINTS = 5;

        // Pilot and ship are one in CylonRaiders
        private readonly int ID;

        public CylonRaider(int ID) : this(ID, DEFAULT_LIFE)
        {
        }

        public CylonRaider(int ID, int Life) : base(Life)
        {
            this.ID = ID;
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
            return "Cylon " + ID;
        }
    }
}
