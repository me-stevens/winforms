using System;

namespace BattlestarGalactica
{
    public class RandomGenerator
    {
        virtual public int Next(int start, int end)
        {
            return (new Random()).Next(start, end);
        }
    }
}
