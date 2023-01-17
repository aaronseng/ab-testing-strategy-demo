using Hanser.AB.Shared;

namespace Hanser.AB.Backend
{
    public static class MockDatabase
    {
        private static readonly Monster Goblin = new() {Health = 75, Power = 10};
        private static readonly Monster GoblinA = new() {Health = 100, Power = 20};
        private static readonly Monster GoblinB = new() {Health = 50, Power = 20};

        private static readonly Power Power = new Power {Magic = 10, Attack = 10};
        private static readonly Power PowerA = new Power {Magic = 10, Attack = 20};
        private static readonly Power PowerB = new Power {Magic = 20, Attack = 10};
        private static readonly Power PowerC = new Power {Magic = 20, Attack = 20};

        private static readonly User John = new() {Name = "John Doe", Power = Power};
        private static readonly User Jane = new() {Name = "Jane Doe", Power = Power};

        public static Monster SelectGoblin(string[] groups)
        {
            if (groups.Contains("Goblin_Config_A"))
            {
                return GoblinA;
            }

            if (groups.Contains("Goblin_Config_B"))
            {
                return GoblinB;
            }

            return Goblin;
        }

        public static User GetUser(string name, string[] groups)
        {
            var user = name == "John" ? John : Jane;

            if (groups.Contains("User_Power_A"))
            {
                user.Power = PowerA;
            }
            else if (groups.Contains("User_Power_B"))
            {
                user.Power = PowerB;
            }
            else if (groups.Contains("User_Power_C"))
            {
                user.Power = PowerC;
            }

            // Simulate Jwt[Groups] put incoming groups data into Jwt[Groups] 
            user.Groups = groups;

            return user;
        }
    }
}