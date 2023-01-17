namespace Hanser.AB.Shared
{
    public interface IMonsterDataLoader
    {
        public Monster Monster { get; }

        public void LoadMonsterConfig(Monster data);
    }
}