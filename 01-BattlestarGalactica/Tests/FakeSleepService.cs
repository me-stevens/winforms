using BattlestarGalactica;

namespace Tests
{
    public class FakeSleepService : SleepService
    {
        public new void Sleep(int miliseconds) {}
    }
}
