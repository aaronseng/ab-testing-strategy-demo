namespace Hanser.AB.Shared.Handlers
{
    public interface IChangeSetHandler
    {
        public bool Handle(ChangeSet changeSet);
    }
}