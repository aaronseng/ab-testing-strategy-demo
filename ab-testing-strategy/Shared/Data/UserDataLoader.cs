namespace Hanser.AB.Shared
{
    public class UserDataLoader : IUserDataLoader
    {
        public User User { get; private set; }

        public void LoadUser(User user)
        {
            User = user;
        }
    }
}