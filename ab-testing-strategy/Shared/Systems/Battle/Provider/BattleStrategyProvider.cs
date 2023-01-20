using Hanser.AB.Shared.Handlers.Strategy;
using Hanser.AB.Shared.Systems.Battle.Provider;

namespace Hanser.AB.Shared
{
    public class BattleStrategyProvider : IBattleStrategyProvider
    {
        private readonly Dictionary<Type, Dictionary<string, IHandlerStrategy>> _handlerStrategies = new Dictionary<Type, Dictionary<string, IHandlerStrategy>>();
        private readonly HashSet<IHandlerStrategy> _provider = new HashSet<IHandlerStrategy>();
        private readonly IUserGroupProvider _groupProvider;

        public BattleStrategyProvider(IUserGroupProvider groupProvider)
        {
            _groupProvider = groupProvider;
        }

        public HashSet<IHandlerStrategy> Provide<T>(IHandlerStrategy defaultStrategy)
        {
            _provider.Clear();
            if (!_handlerStrategies.TryGetValue(typeof(T), out var handlers))
            {
                _provider.Add(defaultStrategy);
                return _provider;
            }

            foreach (var group in _groupProvider.Provide(IUserGroupProvider.Battle))
            {
                _provider.Add(handlers[group]);
            }
            if (_provider.Count == 0)
            {
                _provider.Add(defaultStrategy);
            }

            return _provider;
        }

        public void Register<T>(IHandlerStrategy strategy)
        {
            if (!_handlerStrategies.TryGetValue(typeof(T), out var handlers))
            {
                handlers = new Dictionary<string, IHandlerStrategy>();
                _handlerStrategies.Add(typeof(T), handlers);
            }

            handlers.Add(strategy.Key(), strategy);
        }

        private IHandlerStrategy? GetService<T>(string group)
        {
            return _handlerStrategies.TryGetValue(typeof(T), out var handlers) ? handlers[group] : null;
        }
    }
}