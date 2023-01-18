using Hanser.AB.Shared;
using Hanser.AB.Util;
using Newtonsoft.Json;

namespace Hanser.AB.Unity
{
    public class UnityWebClient
    {
        private const string Uri = "http://localhost:5265/{0}";

        private static User _localUser;

        private async Task<string> Request(string endPoint, string request)
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var response = await client.PostAsync(string.Format(Uri, endPoint), new StringContent(request) );

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<User> Login(string user, string[] groups)
        {
            var request = new LoginRequest {Name = user, Groups = groups};

            var response = await Request("login", JsonConvert.SerializeObject(request));
            _localUser = JsonConvert.DeserializeObject<User>(response);

            Logger.Log("UnityRunner", "WebClient", $"Logged in as '{_localUser.ToString()}' who belongs to the ABGroup [{string.Join(',', _localUser.Groups)}]", false, ConsoleColor.Magenta);

            return _localUser;
        }

        public async Task<Monster> GetMonster()
        {
            if (_localUser.Groups == null)
            {
                Console.WriteLine("JWT is empty. You have to login first");
                return default;
            }

            // Don't need to set Groups when JWT integrated
            var request = new MonsterRequest() {Groups = _localUser.Groups};

            var response = await Request("getMonster", JsonConvert.SerializeObject(request));
            var monster = JsonConvert.DeserializeObject<Monster>(response);

            Logger.Log("UnityRunner", "WebClient", $"Monster Health: {monster.Health} - Power: {monster.Power}", false, ConsoleColor.Magenta);

            return monster;
        }

        public async void SendChangeSet(AttackChangeSet changeSet)
        {
            Logger.Log("UnityRunner", "WebClient", $"Send ChangeSet [{changeSet.GetType().Name}] to the backend", false, ConsoleColor.Magenta);

            // Don't need to set Groups when JWT integrated
            var request = new ChangeSetRequest() {Player = _localUser, ChangeSet = changeSet};
            await Request("sendChangeSet", JsonConvert.SerializeObject(request));
        }
    }
}