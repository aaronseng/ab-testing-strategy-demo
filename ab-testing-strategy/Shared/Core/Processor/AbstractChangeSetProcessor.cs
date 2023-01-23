using Hanser.AB.Shared.Handlers;

namespace Hanser.AB.Shared
{
    public abstract class AbstractChangeSetProcessor : IChangeSetProcessor
    {
        private readonly Dictionary<Type, IChangeSetHandler> _handlerDispatcher = new Dictionary<Type, IChangeSetHandler>();

        public virtual bool Process(ChangeSet changeSet)
        {
            if (_handlerDispatcher.TryGetValue(changeSet.GetType(), out var handler))
            {
                return handler.Handle(changeSet);
            }

            Console.WriteLine($"Couldn't find a handler for the {changeSet.GetType()}");
            return false;
        }

        protected void RegisterHandler<T, T2>(T2 handler) where T : ChangeSet where T2 : IChangeSetHandler
        {
            _handlerDispatcher.Add(typeof(T), handler);
        }
    }
}