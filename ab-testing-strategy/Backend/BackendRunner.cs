using Hanser.AB.Shared;

namespace Hanser.AB.Backend
{
    public class BackendRunner
    {
        private readonly IGameEngineDataLoader _gameEngineDataLoader;
        private readonly ChangeSetProcessor _changeSetProcessor;

        public BackendRunner(ChangeSetProcessor changeSetProcessor, IGameEngineDataLoader gameEngineDataLoader)
        {
            _gameEngineDataLoader = gameEngineDataLoader;
            _changeSetProcessor = changeSetProcessor;

            _changeSetProcessor.Runner = nameof(BackendRunner);
        }

        public void Run()
        {
            Console.WriteLine($"{Environment.NewLine}# INITIALIZING BACKEND ENVIRONMENT #");

        }
    }
}