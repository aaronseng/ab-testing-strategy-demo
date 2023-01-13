using Hanser.AB.Shared;

namespace Hanser.AB.Unity
{
    public class UnityRunner
    {
        private readonly IGameEngineDataLoader _gameEngineDataLoader;
        private readonly GameEngine _gameEngine;

        public UnityRunner(IGameEngineDataLoader gameEngineDataLoader, GameEngine gameEngine)
        {
            _gameEngineDataLoader = gameEngineDataLoader;
            _gameEngine = gameEngine;
        }
        
        public void Run()
        {
            Console.WriteLine("# SIMULATING AB-TESTING DATA #");
            
            Console.WriteLine($"{Environment.NewLine}UnityRunner >> Logging in...");
            var user = MockWebClient.Login();

            Console.WriteLine($"{Environment.NewLine}UnityRunner >> Getting monster config...");
            var monster = MockWebClient.GetGoblin();

            Console.WriteLine($"{Environment.NewLine}# SETTING-UP GAME ENGINE FOR THE UNITY RUNNER #");

            _gameEngineDataLoader.LoadMonsterConfig(monster);

        }
    }
}