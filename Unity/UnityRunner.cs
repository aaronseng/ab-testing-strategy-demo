using Hanser.AB.Shared;
using Hanser.AB.Util;

namespace Hanser.AB.Unity
{
    public class UnityRunner
    {
        private readonly IGameEngineDataLoader _gameEngineDataLoader;
        private readonly ChangeSetProcessor _changeSetProcessor;

        private struct FirebaseModel
        {
            public string[] Groups;

            public FirebaseModel()
            {
                Groups = new[] {string.Empty};
            }
        }

        public UnityRunner(IGameEngineDataLoader gameEngineDataLoader, ChangeSetProcessor changeSetProcessor)
        {
            _gameEngineDataLoader = gameEngineDataLoader;
            _changeSetProcessor = changeSetProcessor;

            _changeSetProcessor.Runner = nameof(UnityRunner);
        }

        public void Run()
        {
            Console.WriteLine("# SIMULATING AB-TESTING DATA #");

            var mockFirebase = new FirebaseModel() {Groups = new string[] {"Goblin_Config_A", "User_Power_C"}};
            Logger.Log("UnityRunner", "Firebase", $"Received user group data Groups: [{string.Join(", ", mockFirebase.Groups)}]", true, ConsoleColor.DarkRed);

            Logger.Log("UnityRunner", string.Empty, "Logging in...");
            var user = MockWebClient.Login("John", mockFirebase.Groups);

            Logger.Log("UnityRunner", string.Empty, "Getting monster config...");
            var monster = MockWebClient.GetGoblin();

            Console.WriteLine($"{Environment.NewLine}# SETTING-UP GAME ENGINE FOR THE UNITY RUNNER #");

            _gameEngineDataLoader.LoadUser(user);
            _gameEngineDataLoader.LoadMonsterConfig(monster);

            var attack = new AttackChangeSet() {Id = new Guid(), Power = user.Power};

            Logger.Log("UnityRunner", string.Empty, "Running a ChangeSet...");
            _changeSetProcessor.ProcessChangeSet(attack);

            MockWebClient.SendChangeSet(attack);
        }
    }
}