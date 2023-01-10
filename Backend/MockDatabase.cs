using Hanser.AB.Shared;

namespace Hanser.AB.Backend
{
    public static class MockDatabase
    {
        private static readonly Monster GoblinA = new() {Health = 100, Power = 20};
        private static readonly Monster GoblinB = new() {Health = 50, Power = 10, Version = "B"};

        private static readonly User UserA = new() {Name = "John Doe"};
        private static readonly User UserB = new() {Name = "Jane Doe", Group = "B"};

        public static Monster SelectGoblin(string version)
        {
            return version == "A" ? GoblinA : GoblinB;
        }

        public static User GetUser(string group)
        {
            return group == "A" ? UserA : UserB;
        }
    }
}