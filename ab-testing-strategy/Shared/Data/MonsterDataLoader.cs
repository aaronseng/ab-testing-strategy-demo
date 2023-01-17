namespace Hanser.AB.Shared
{
    public class MonsterDataLoader : IMonsterDataLoader
    {
        public Monster Monster { get; private set; }

        public void LoadMonsterConfig(Monster monster)
        {
            Monster = monster;
        }
    }
}