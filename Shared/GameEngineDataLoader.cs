namespace Hanser.AB.Shared
{
    public class GameEngineDataLoader : IGameEngineDataLoader
    {
        public Monster Monster { get; private set; }
        
        public void LoadMonsterConfig(Monster data)
        {
            Monster = data;
        }
    }
}