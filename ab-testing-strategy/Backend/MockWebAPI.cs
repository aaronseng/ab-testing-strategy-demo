using Hanser.AB.Shared;
using Hanser.AB.Util;

namespace Hanser.AB.Backend
{
    public static class MockWebAPI
    {
        private static string[] Jwt = {string.Empty};

        /// <summary>
        /// Simulate Header for the request
        /// </summary>
        /// <param name="jwt">Jwt token</param>
        public static void SetHeader(string[] jwt)
        {
            Jwt = jwt;
        }

        /// <summary>
        /// Returns a random user who belongs to group 'A' or 'B'
        /// </summary>
        /// <returns>User</returns>
        public static User Login(string user, string[] groups)
        {
            return MockDatabase.GetUser(user, groups);
        }

        /// <summary>
        /// Returns a goblin
        /// </summary>
        /// <returns>Goblin</returns>
        public static Monster GetGoblin()
        {
            // Extract [Groups] from JWT payload
            var abVersion = Jwt;

            var data = MockDatabase.SelectGoblin(Jwt);

            return data;
        }

        public static void SendChangeSet(ChangeSet changeSet)
        {
            Logger.Log("Backend2", "WebAPI", $"Received ChangeSet [{changeSet.GetType().Name}]", true, ConsoleColor.DarkMagenta);
        }
    }
}