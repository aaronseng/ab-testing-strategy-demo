namespace Hanser.AB.Shared
{
    public interface IChangeSetProcessor
    {
        public bool Process(ChangeSet changeSet);
    }
}