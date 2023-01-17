using Hanser.AB.Shared.Factory;
using Hanser.AB.Util;

namespace Hanser.AB.Shared.Handlers
{
    public class BoostedAttackLogicHandler : IAttackLogicHandler
    {
        private readonly IGameEngineDataLoader _dataProvider;

        public string Runner { get; set; } = string.Empty;

        private BoostedAttackLogicHandler(IGameEngineDataLoader dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void Damage(AttackChangeSet changeSet)
        {
            Logger.Log(Runner, "Shared", $"BoostedAttackLogicHandler processing changeSet with Power [{changeSet.Power}] x 2 going to hit Monster with [Health : {_dataProvider.Monster.Health}]", false, ConsoleColor.Yellow);
        }

        public static IAttackLogicHandler Create(IGameEngineDataLoader dataProvider)
        {
            return new BoostedAttackLogicHandler(dataProvider);
        }
    }
}