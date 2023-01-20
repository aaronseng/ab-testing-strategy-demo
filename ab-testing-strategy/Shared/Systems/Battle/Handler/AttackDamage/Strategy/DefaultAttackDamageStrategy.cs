using Hanser.AB.Shared.Handlers;
using Hanser.AB.Shared.Systems.Battle.Provider;
using Hanser.AB.Util;

namespace Hanser.AB.Shared.Systems.Battle.Handler.Strategy
{
    public class DefaultAttackDamageStrategy : IBattleHandlerStrategy
    {
        private const string GroupKey = "Battle_AttackDamage_Default";

        public DefaultAttackDamageStrategy(IBattleStrategyProvider provider)
        {
            provider.Register<AttackDamageHandler>(this);
        }
        
        public IStrategyResult Handle(IStrategyResult result)
        {
            Logger.Log($"Shared][{nameof(DefaultAttackDamageStrategy)}", " Do some Attack damage", false, ConsoleColor.Yellow);

            result.Result = true;
            return result;
        }

        public string Key()
        {
            return GroupKey;
        }
    }
}