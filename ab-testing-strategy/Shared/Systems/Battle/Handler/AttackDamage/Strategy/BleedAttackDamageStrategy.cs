using Hanser.AB.Shared.Handlers;
using Hanser.AB.Shared.Systems.Battle.Provider;
using Hanser.AB.Util;

namespace Hanser.AB.Shared.Systems.Battle.Handler.Strategy
{
    public class BleedAttackDamageStrategy : IBattleHandlerStrategy
    {
        private const string GroupKey = "Battle_AttackDamage_Bleed";

        public BleedAttackDamageStrategy(IBattleStrategyProvider provider)
        {
            provider.Register<AttackDamageHandler>(this);
        }
        
        public IStrategyResult Handle(IStrategyResult result)
        {
            Logger.Log($"Shared][{nameof(BleedAttackDamageStrategy)}", "Add Bleed damage", false, ConsoleColor.Yellow);

            result.Result = true;
            return result;
        }

        public string Key()
        {
            return GroupKey;
        }
    }
}