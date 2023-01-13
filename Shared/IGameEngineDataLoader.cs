namespace Hanser.AB.Shared
{
    public interface IGameEngineDataLoader
    {
        public User User { get; }
        public Monster Monster { get; }

        public void LoadMonsterConfig(Monster data);

        public void LoadUser(User user);
    }
}