using Hanser.AB.Shared.Battle;
using Hanser.AB.Util;

namespace Hanser.AB.Shared
{
    public class ChangeSetProcessor : IChangeSetProcessor
    {
        private readonly Dictionary<Type, IChangeSetProcessor> _processorDispatcher = new Dictionary<Type, IChangeSetProcessor>();

        public ChangeSetProcessor(BattleChangeSetProcessor battleChangeSetProcessor)
        {
            RegisterProcessor<BattleChangeSet, BattleChangeSetProcessor>(battleChangeSetProcessor);
        }

        public bool Process(ChangeSet changeSet)
        {
            var baseType = changeSet.GetType().BaseType;

            Logger.Log($"Shared][{nameof(ChangeSetProcessor)}", $"Processing ChangeSet [{baseType?.Name}]", false, ConsoleColor.Yellow);

            if (baseType != null && _processorDispatcher.TryGetValue(baseType, out var handler))
            {
                return handler.Process(changeSet);
            }

            Console.WriteLine($"Couldn't find a sub Processor for the {changeSet.GetType()}");
            return false;
        }

        private void RegisterProcessor<T, T2>(T2 handler) where T : ChangeSet where T2 : IChangeSetProcessor
        {
            _processorDispatcher.Add(typeof(T), handler);
        }
    }
}