namespace Hanser.AB.Shared
{
    public interface IGameEngineDataLoader
    {
        public IUserDataLoader UserDataProvider { get;}
        public IMonsterDataLoader MonsterDataProvider { get; }
    }
}