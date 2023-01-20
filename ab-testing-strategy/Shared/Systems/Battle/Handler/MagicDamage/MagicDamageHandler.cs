using Hanser.AB.Shared.Handlers;
using Hanser.AB.Shared.Systems.Battle.Handler.Strategy;
using Hanser.AB.Shared.Systems.Battle.Provider;
using Hanser.AB.Util;
using Shared.Handler.Strategy;

namespace Hanser.AB.Shared.Systems.Battle.Handler
{
    public class MagicDamageHandler : IChangeSetHandler
    {
        private readonly IBattleStrategyProvider _strategyProvider;
        private readonly DefaultMagicDamageStrategy _defaultStrategy;

        public MagicDamageHandler(DefaultMagicDamageStrategy defaultStrategy, IBattleStrategyProvider strategyProvider)
        {
            _strategyProvider = strategyProvider;
            _defaultStrategy = defaultStrategy;
        }
        
        public bool Handle(ChangeSet changeSet)
        {
            Logger.Log($"Shared][{nameof(MagicDamageHandler)}", $"Handling ChangeSet [{changeSet.GetType().Name}]", false, ConsoleColor.Yellow);

            var strategies = _strategyProvider.Provide<MagicDamageHandler>(_defaultStrategy);
            IStrategyResult result = new BasicStrategyResult { Result = true };
            foreach (var strategy in strategies)
            {
                result = strategy.Handle(result);
                if (!result.Result)
                {
                    return false;
                }
            }

            return true;
        }
    }
}