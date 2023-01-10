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
            // user.Group will be used as JWT [version] payload
            MockWebAPI.Jwt = _localUser.Group;

            Console.WriteLine($"Logged in as '{_localUser.Name}' who belongs to the ABGroup [{_localUser.Group}] ");

            return _localUser;
        }

        public static Monster GetGoblin()
        {
            if (string.IsNullOrEmpty(MockWebAPI.Jwt))
            {
                Console.WriteLine("JWT is empty. You have to login first");
                return default;
            }

            var goblin = MockWebAPI.GetGoblin();

            Console.WriteLine($"Goblin Health: {goblin.Health} - Power: {goblin.Power} - Version: {goblin.Version}");

            return goblin;
        }
    }
}