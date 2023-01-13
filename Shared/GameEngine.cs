namespace Hanser.AB.Shared
{
    public class GameEngine
    {
        private readonly IGameEngineDataLoader _dataLoader;
        private readonly ChangeSetProcessor _changeSetProcessor;

        public GameEngine(IGameEngineDataLoader dataLoader, ChangeSetProcessor changeSetProcessor)
        {
            _dataLoader = dataLoader;
            _changeSetProcessor = changeSetProcessor;
        }
    }
}