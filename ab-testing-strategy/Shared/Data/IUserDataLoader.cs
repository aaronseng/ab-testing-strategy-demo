namespace Hanser.AB.Shared;

public interface IUserDataLoader
{
    public User User { get; }

    public void LoadUser(User user);
}