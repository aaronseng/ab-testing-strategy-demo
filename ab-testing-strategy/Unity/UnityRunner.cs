using System.Net.Http.Headers;
using Hanser.AB.Shared;
using Hanser.AB.Util;

namespace Hanser.AB.Unity
{
    public class UnityRunner
    {
        private readonly IGameEngineDataLoader _gameEngineDataLoader;
        private readonly ChangeSetProcessor _changeSetProcessor;

        public UnityRunner(ChangeSetProcessor changeSetProcessor, IGameEngineDataLoader gameEngineDataLoader)
        {
            _gameEngineDataLoader = gameEngineDataLoader;
            _changeSetProcessor = changeSetProcessor;

            _changeSetProcessor.Runner = nameof(UnityRunner);
        }

        public async void Run(string uid, FirebaseModel mockFirebase)
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")); 
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            await ProcessRepositoriesAsync(client);

            static async Task ProcessRepositoriesAsync(HttpClient client)
            {
                var json = await client.PostAsync("https://localhost:7292/login", new StringContent("HARUN asdfasdf") );

                Console.Write(json);
            }
            
            Console.WriteLine($"{Environment.NewLine}# SIMULATING AB-TESTING DATA #");

            Logger.Log("UnityRunner", "Firebase", $"Received user group data Groups: [{string.Join(", ", mockFirebase.Groups)}]", true, ConsoleColor.DarkRed);

            Logger.Log("UnityRunner", string.Empty, "Logging in...");
            var user = MockWebClient.Login(uid, mockFirebase.Groups);

            Logger.Log("UnityRunner", string.Empty, "Getting monster config...");
            var monster = MockWebClient.GetGoblin();

            Console.WriteLine($"{Environment.NewLine}# SETTING-UP GAME ENGINE FOR THE UNITY RUNNER #");

            _gameEngineDataLoader.UserDataProvider.LoadUser(user);
            _gameEngineDataLoader.MonsterDataProvider.LoadMonsterConfig(monster);

            var attack = new AttackChangeSet() {Id = new Guid(), Power = user.Power};

            Logger.Log("UnityRunner", string.Empty, "Running a ChangeSet...");
            _changeSetProcessor.ProcessChangeSet(attack);

            MockWebClient.SendChangeSet(attack);
        }
    }
}