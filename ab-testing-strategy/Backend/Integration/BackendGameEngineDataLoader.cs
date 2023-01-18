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
        MonsterDataProvider = monsterDataLoader;

        LoadAllMonsterData();
    }

    public void SwitchContext()
    {
        foreach (var group in UserDataProvider.User.Groups)
        {
            if (Monsters.TryGetValue(group, out var monster))
            {
                MonsterDataProvider.LoadMonsterConfig(monster);
                return;
            }
        }

        MonsterDataProvider.LoadMonsterConfig(Monsters["default_monster"]);
    }

    private void LoadAllMonsterData()
    {
        Monsters.Add("default_monster", MockDatabase.SelectGoblin(new[] {"default_monster"}));
        Monsters.Add("Goblin_Config_A", MockDatabase.SelectGoblin(new[] {"Goblin_Config_A"}));
        Monsters.Add("Goblin_Config_B", MockDatabase.SelectGoblin(new[] {"Goblin_Config_B"}));
    }
}