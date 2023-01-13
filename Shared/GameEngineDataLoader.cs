namespace Hanser.AB.Shared
{
    public class GameEngineDataLoader : IGameEngineDataLoader
    {
        public User User { get; private set; }
        public Monster Monster { get; private set; }

        public void LoadMonsterConfig(Monster data)
        {
            Monster = data;
        }

        public void LoadUser(User user)
        {
            User = user;
        }
    }
}