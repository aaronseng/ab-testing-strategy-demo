using Hanser.AB.Shared.Factory;
using Hanser.AB.Util;

namespace Hanser.AB.Shared.Handlers
{
    public class AttackLogicHandler : IAttackLogicHandler
    {
        private readonly IGameEngineDataLoader _dataProvider;

        public string Runner { get; set; } = string.Empty;

        private AttackLogicHandler(IGameEngineDataLoader dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void Damage(AttackChangeSet changeSet)
        {
            Logger.Log(Runner, "Shared", $"AttackLogicHandler processing changeSet with Power [{changeSet.Power}] going to hit Monster with [Health : {_dataProvider.Monster.Health}]", false, ConsoleColor.Yellow);
        }

        public static IAttackLogicHandler Create(IGameEngineDataLoader dataProvider)
        {
            return new AttackLogicHandler(dataProvider);
        }
    }
}