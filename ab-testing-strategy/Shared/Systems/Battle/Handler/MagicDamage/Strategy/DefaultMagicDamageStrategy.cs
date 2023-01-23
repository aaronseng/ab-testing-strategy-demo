using Hanser.AB.Shared.Handlers;
using Hanser.AB.Shared.Systems.Battle.Provider;
using Hanser.AB.Util;

namespace Hanser.AB.Shared.Systems.Battle.Handler.Strategy
{
    public class DefaultMagicDamageStrategy : IBattleHandlerStrategy
    {
        private const string GroupKey = "Battle_MagicDamage_Default";

        public DefaultMagicDamageStrategy(IBattleStrategyProvider provider)
        {
            provider.Register<MagicDamageHandler>(this);
        }

        public IStrategyResult Handle(IStrategyResult result)
        {
            Logger.Log($"Shared][{nameof(DefaultMagicDamageStrategy)}", " Do some Magic damage", false, ConsoleColor.Yellow);

            result.Result = true;
            return result;
        }

        public string Key()
        {
            return GroupKey;
        }
    }
}