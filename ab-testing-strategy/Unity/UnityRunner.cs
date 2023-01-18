using System.Net.Http.Headers;
using Hanser.AB.Shared;
using Hanser.AB.Util;

namespace Hanser.AB.Unity
{
    public class UnityRunner
    {
        private readonly IGameEngineDataLoader _gameEngineDataLoader;
        private readonly ChangeSetProcessor _changeSetProcessor;
        private readonly UnityWebClient _webClient;

        public UnityRunner(ChangeSetProcessor changeSetProcessor, IGameEngineDataLoader gameEngineDataLoader, UnityWebClient webClient)
        {
            _gameEngineDataLoader = gameEngineDataLoader;
            _changeSetProcessor = changeSetProcessor;
            _webClient = webClient;

            _changeSetProcessor.Runner = nameof(UnityRunner);
        }

        public async Task Run(string uid, FirebaseModel mockFirebase)
        {
            Console.WriteLine($"{Environment.NewLine}# SIMULATING AB-TESTING DATA #");

            Logger.Log("UnityRunner", "Firebase", $"Received user group data Groups: [{string.Join(", ", mockFirebase.Groups)}]", true, ConsoleColor.DarkRed);

            Logger.Log("UnityRunner", string.Empty, "Logging in...");
            var user = await _webClient.Login(uid, mockFirebase.Groups);

            Logger.Log("UnityRunner", string.Empty, "Getting monster config...");
            var monster = await _webClient.GetMonster();

            Console.WriteLine($"{Environment.NewLine}# SETTING-UP GAME ENGINE FOR THE UNITY RUNNER #");

            _gameEngineDataLoader.UserDataProvider.LoadUser(user);
            _gameEngineDataLoader.MonsterDataProvider.LoadMonsterConfig(monster);

            var attack = new AttackChangeSet() {Id = new Guid(), Power = user.Power};

            Logger.Log("UnityRunner", string.Empty, "Running a ChangeSet...");
            _changeSetProcessor.ProcessChangeSet(attack);

            _webClient.SendChangeSet(attack);
        }
    }
}