namespace Hanser.AB.Shared
{
    public class UnityGameEngineDataLoader : IGameEngineDataLoader
    {
        public IUserDataLoader UserDataProvider { get; private set; }
        public IMonsterDataLoader MonsterDataProvider { get; private set; }
        
        public UnityGameEngineDataLoader(IUserDataLoader userDataLoader, IMonsterDataLoader monsterDataLoader)
        {
            UserDataProvider = userDataLoader;
            MonsterDataProvider = monsterDataLoader;
        }
    }
}