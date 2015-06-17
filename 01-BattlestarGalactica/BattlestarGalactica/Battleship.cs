namespace BattlestarGalactica
{
    public class Battleship
    {
        public const int DEFAULT_LIFE = 10;
        public const string DEFAULT_NAME = "Battleship";

        // The special way C sharp has to define an attribute
        // as well as its setter and getter in one go:
        public int Life
        {
            get;
            set;
        }
        private RandomGenerator random;

        public Battleship() : this(DEFAULT_LIFE)
        {
        }

        public Battleship(int life) : this(life, new RandomGenerator())
        {
        }

        public Battleship(int life, RandomGenerator random)
        {
            this.Life = life;
            this.random = random;
        }

        public bool IsDead()
        {
            return Life <= 0;
        }

        virtual public Battleship Shoot(Battleship[,] targets)
        {
            Battleship target = null;

            do
            {
                int i = random.Next(0, targets.GetLength(0));
                int j = random.Next(0, targets.GetLength(1));
                target = targets[i, j];

            } while (target.IsDead());

            target.Receive();
            return target;
        }

        virtual public void Receive()
        {
            // Implemented by child classes
        }

        virtual public string PrintableName()
        {
            return DEFAULT_NAME;
        }
    }
}
