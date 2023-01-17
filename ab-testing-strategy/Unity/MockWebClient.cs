using System.Net.Http.Headers;
using Hanser.AB.Backend;
using Hanser.AB.Shared;
using Hanser.AB.Util;

namespace Hanser.AB.Unity
{
    public static class MockWebClient
    {
        private static User _localUser;

        public static User Login(string user, string[] groups)
        {
            _localUser = MockWebAPI.Login(user, groups);

            Logger.Log("UnityRunner", "WebClient", $"Logged in as '{_localUser.ToString()}' who belongs to the ABGroup [{string.Join(',', _localUser.Groups)}]", false, ConsoleColor.Magenta);

            return _localUser;
        }

        public static Monster GetGoblin()
        {
            if (_localUser.Groups == null)
            {
                Console.WriteLine("JWT is empty. You have to login first");
                return default;
            }

            // User.Group will be used as JWT [version] payload
            MockWebAPI.SetHeader(_localUser.Groups);
            var goblin = MockWebAPI.GetGoblin();

            Logger.Log("UnityRunner", "WebClient", $"Goblin Health: {goblin.Health} - Power: {goblin.Power}", false, ConsoleColor.Magenta);

            return goblin;
        }

        public static void SendChangeSet(ChangeSet changeSet)
        {
            Logger.Log("UnityRunner", "WebClient", $"Send ChangeSet [{changeSet.GetType().Name}] to the backend", false, ConsoleColor.Magenta);

            MockWebAPI.SetHeader(_localUser.Groups);
            MockWebAPI.SendChangeSet(changeSet);
        }
    }
}