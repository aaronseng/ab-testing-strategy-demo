namespace Hanser.AB.Shared
{
    public class UserGroupProvider : IUserGroupProvider
    {
        private readonly IUserDataLoader _userDataProvider;

        public UserGroupProvider(IUserDataLoader userDataProvider)
        {
            _userDataProvider = userDataProvider;
        }

        public IEnumerable<string> Provide(string prefix = "")
        {
            return _userDataProvider.User.Groups!.Where(group => group.StartsWith(prefix));
        }
    }
}