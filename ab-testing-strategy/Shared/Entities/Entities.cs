using System.Text.RegularExpressions;

namespace Hanser.AB.Shared
{
    public struct LoginRequest
    {
        public string Name;
        public string[] Groups;

        public LoginRequest()
        {
            Name = "";
            Groups = Array.Empty<string>();
        }
    }

    public struct MonsterRequest
    {
        public string[] Groups;

        public MonsterRequest()
        {
            Groups = Array.Empty<string>();
        }
    }

    public struct ChangeSetRequest
    {
        public BattleChangeSet ChangeSet;
        public User Player;

        public ChangeSetRequest()
        {
            ChangeSet = null;
            Player = default;
        }
    }
    
    public struct FirebaseModel
    {
        public string[] Groups;

        public FirebaseModel()
        {
            Groups = new[] {string.Empty};
        }
    }
    
    public struct Monster
    {
        public float Health;
        public float Power;

        public Monster()
        {
            Health = 0;
            Power = 0;
        }
    }

    public struct User
    {
        public string Name;
        public Power Power;
        public string[]? Groups;

        public User()
        {
            Name = string.Empty;
            Power = new Power();
            Groups = null;
        }

        public override string ToString()
        {
            return $"Name: {Name} - Attack: {Power.Attack} - Magic: {Power.Magic}";
        }
    }

    public struct Power
    {
        public int Magic;
        public int Attack;

        public Power()
        {
            Magic = 0;
            Attack = 0;
        }

        public override string ToString()
        {
            return $"Attack: {Attack} - Magic: {Magic}";
        }
    }
}