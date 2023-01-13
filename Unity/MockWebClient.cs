using Hanser.AB.Backend;
using Hanser.AB.Shared;

namespace Hanser.AB.Unity
{
    public static class MockWebClient
    {
        private static User _localUser;

        public static User Login()
        {
            _localUser = MockWebAPI.Login();

            Console.WriteLine($"Logged in as '{_localUser.Name}' who belongs to the ABGroup [{_localUser.Group}] ");

            return _localUser;
        }

        public static Monster GetGoblin()
        {
            if (string.IsNullOrEmpty(_localUser.Group))
            {
                Console.WriteLine("JWT is empty. You have to login first");
                return default;
            }

            // User.Group will be used as JWT [version] payload
            MockWebAPI.SetHeader(_localUser.Group);
            var goblin = MockWebAPI.GetGoblin();

            Console.WriteLine($"Goblin Health: {goblin.Health} - Power: {goblin.Power} - Version: {goblin.Version}");

            return goblin;
        }
    }
}