using Hanser.AB.Shared.Factory;
using Hanser.AB.Util;

namespace Hanser.AB.Shared.Handlers
{
    public class AttackLogicHandler : IAttackLogicHandler
    {
        private readonly IGameEngineDataLoader _gameEngineDataLoader;

        public string Runner { get; set; } = string.Empty;

        private AttackLogicHandler(IGameEngineDataLoader gameEngineDataLoader)
        {
            _gameEngineDataLoader = gameEngineDataLoader;
        }

        public void Damage(AttackChangeSet changeSet)
        {
            Logger.Log(Runner, "Shared", $"AttackLogicHandler processing changeSet with Power [{changeSet.Power}] going to hit Monster with [Health : {_gameEngineDataLoader.MonsterDataProvider.Monster.Health}]", false, ConsoleColor.Yellow);
        }

        public static IAttackLogicHandler Create(IGameEngineDataLoader gameEngineDataLoader)
        {
            return new AttackLogicHandler(gameEngineDataLoader);
        }
    }
}