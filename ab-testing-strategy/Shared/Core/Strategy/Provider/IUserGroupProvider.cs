namespace Hanser.AB.Shared;

public interface IUserGroupProvider
{
    public const string Battle = "Battle_";

    public IEnumerable<string> Provide(string prefix = "");
}