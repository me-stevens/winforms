using System.Collections;

using BattlestarGalactica;

namespace Tests
{
    public class FakeRandomGenerator : RandomGenerator
    {
        private Stack fakeValues;

        public FakeRandomGenerator(Stack fakeValues)
        {
            this.fakeValues = fakeValues;
        }

        override public int Next(int start, int end)
        {
            return (int)fakeValues.Pop();
        }
    }
}
