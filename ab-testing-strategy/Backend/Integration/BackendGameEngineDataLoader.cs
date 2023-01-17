using Hanser.AB.Shared;

namespace Hanser.AB.Backend.Integration;

public class BackendGameEngineDataLoader : IGameEngineDataLoader
{
    private readonly Dictionary<string, Monster> Monsters = new Dictionary<string, Monster>();
    public IUserDataLoader UserDataProvider { get; }
    public IMonsterDataLoader MonsterDataProvider { get; }

    public BackendGameEngineDataLoader(IUserDataLoader userDataLoader, IMonsterDataLoader monsterDataLoader)
    {
        UserDataProvider = userDataLoader;
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
    }
}