namespace Hanser.AB.Shared
{
    public class ChangeSetProcessor
    {
        public string Runner { get; set; }

        public ChangeSetProcessor()
        {
        }

        public bool ProcessChangeSet(ChangeSet changeSet)
        {
            Console.WriteLine($"{Environment.NewLine}[{Runner}][Shared] : Processing ChangeSet [{changeSet.GetType().Name}]");
            return true;
        }
    }
}