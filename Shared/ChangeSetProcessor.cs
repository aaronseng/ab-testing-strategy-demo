using Hanser.AB.Util;

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
            Logger.Log(Runner, "Shared", $"Processing ChangeSet [{changeSet.GetType().Name}]", false, ConsoleColor.Yellow);
            return true;
        }
    }
}