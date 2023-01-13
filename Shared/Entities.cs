namespace Hanser.AB.Shared
{
    public struct Monster
    {
        public float Health;
        public float Power;
        public string Version = "A";

        public Monster()
        {
            Health = 0;
            Power = 0;
        }
    }

    public struct User
    {
        public string Name;
        public string Group = "A";

        public User()
        {
            Name = string.Empty;
        }
    }
}