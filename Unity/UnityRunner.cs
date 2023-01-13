using Hanser.AB.Shared;

namespace Hanser.AB.Unity
{
    public class UnityRunner
    {
        private readonly IGameEngineDataLoader _gameEngineDataLoader;
        private readonly ChangeSetProcessor _changeSetProcessor;

        public UnityRunner(IGameEngineDataLoader gameEngineDataLoader, ChangeSetProcessor changeSetProcessor)
        {
            _gameEngineDataLoader = gameEngineDataLoader;
            _changeSetProcessor = changeSetProcessor;

            _changeSetProcessor.Runner = nameof(UnityRunner);
        }

        public void Run()
        {
            Console.WriteLine("# SIMULATING AB-TESTING DATA #");

            Console.WriteLine($"{Environment.NewLine}[UnityRunner] : Logging in...");
            var user = MockWebClient.Login();

            Console.WriteLine($"{Environment.NewLine}[UnityRunner] : Getting monster config...");
            var monster = MockWebClient.GetGoblin();

            Console.WriteLine($"{Environment.NewLine}# SETTING-UP GAME ENGINE FOR THE UNITY RUNNER #");

            _gameEngineDataLoader.LoadUser(user);
            _gameEngineDataLoader.LoadMonsterConfig(monster);

            var attack = new AttackChangeSet() { Id = new Guid(), Power = user.Power };

            //Console.WriteLine($"{Environment.NewLine}[UnityRunner] : Processing an AttackChangeSet [Attack: {attack.Power.Attack} - Group: {attack.Power.Group}]");
            _changeSetProcessor.ProcessChangeSet(attack);

            MockWebClient.SendChangeSet(attack);
        }
    }
}