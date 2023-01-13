using Hanser.AB.Shared;

namespace Hanser.AB.Backend
{
    public static class MockWebAPI
    {
        private static readonly Random Generator = new Random(DateTime.UtcNow.Millisecond);

        private static string Jwt;

        /// <summary>
        /// Simulate Header for the request
        /// </summary>
        /// <param name="jwt">Jwt token</param>
        public static void SetHeader(string jwt)
        {
            Jwt = jwt;
        }

        /// <summary>
        /// Returns a random user who belongs to group 'A' or 'B'
        /// </summary>
        /// <returns>User</returns>
        public static User Login()
        {
            return MockDatabase.GetUser(Generator.Next(0, 2) == 0 ? "A" : "B");
        }

        /// <summary>
        /// Returns a goblin
        /// </summary>
        /// <returns>Goblin</returns>
        public static Monster GetGoblin()
        {
            // Extract [version] from JWT payload
            var abVersion = Jwt;

            var data = MockDatabase.SelectGoblin(abVersion);

            return data;
        }
    }
}