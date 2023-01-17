using Hanser.AB.Shared.Factory;
using Hanser.AB.Shared.Handlers;
using Hanser.AB.Util;

namespace Hanser.AB.Shared
{
    public class ChangeSetProcessor
    {
        private readonly IAttackLogicFactory _attackLogicFactory;
        public string Runner { get; set; } = string.Empty;

        public ChangeSetProcessor(IAttackLogicFactory attackLogicFactory)
        {
            _attackLogicFactory = attackLogicFactory;

            Initialize();
        }

        public void ProcessChangeSet(ChangeSet changeSet)
        {
            Logger.Log(Runner, "Shared", $"Handling ChangeSet [{changeSet.GetType().Name}]", false, ConsoleColor.Yellow);

            if (changeSet is AttackChangeSet attackChangeSet)
            {
                var handler = _attackLogicFactory.GetHandler();
                handler.Runner = Runner;
                handler.Damage(attackChangeSet);
            }
        }

        private void Initialize()
        {
            // Register factory methods
            AttackLogicFactory.Register("default", AttackLogicHandler.Create);
            AttackLogicFactory.Register("Attack_Handler_Boosted", BoostedAttackLogicHandler.Create);
        }
    }
}