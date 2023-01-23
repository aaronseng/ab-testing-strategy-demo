using Hanser.AB.Shared;
using Hanser.AB.Shared.Systems.Battle.Handler.Strategy;
using Hanser.AB.Util;

namespace Hanser.AB.Unity
{
    public class UnityRunner
    {
        private readonly IGameEngineDataLoader _gameEngineDataLoader;
        private readonly ChangeSetProcessor _changeSetProcessor;
        private readonly UnityWebClient _webClient;

        public UnityRunner(IEnumerable<IBattleHandlerStrategy> strategies, ChangeSetProcessor changeSetProcessor, IGameEngineDataLoader gameEngineDataLoader, UnityWebClient webClient)
        {
            _gameEngineDataLoader = gameEngineDataLoader;
            _changeSetProcessor = changeSetProcessor;
            _webClient = webClient;

            Logger.Runner = nameof(UnityRunner);
        }

        public async Task Run(string uid, FirebaseModel mockFirebase)
        {
            Console.WriteLine($"{Environment.NewLine}# SIMULATING AB-TESTING DATA #");

            Logger.Log("Firebase", $"Received user group data Groups: [{string.Join(", ", mockFirebase.Groups)}]", true, ConsoleColor.DarkRed);

            Logger.Log(string.Empty, "Logging in...");
            var user = await _webClient.Login(uid, mockFirebase.Groups);

            Logger.Log(string.Empty, "Getting monster config...");
            var monster = await _webClient.GetMonster();

            Console.WriteLine($"{Environment.NewLine}# SETTING-UP GAME ENGINE FOR THE UNITY RUNNER #");

            _gameEngineDataLoader.UserDataProvider.LoadUser(user);
            _gameEngineDataLoader.MonsterDataProvider.LoadMonsterConfig(monster);

            var attack = new AttackDamageChangeSet() { Id = Guid.NewGuid(), Power = user.Power };

            Logger.Log(string.Empty, "Running a ChangeSet...");
            _changeSetProcessor.Process(attack);

            await _webClient.SendChangeSet(attack);

            var magic = new MagicDamageChangeSet() { Id = Guid.NewGuid(), Power = user.Power };

            Logger.Log(string.Empty, "Running a ChangeSet...");
            _changeSetProcessor.Process(magic);

            await _webClient.SendChangeSet(magic);
        }
    }
}