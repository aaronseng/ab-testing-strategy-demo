using Hanser.AB.Shared.Systems.Battle.Handler;

namespace Hanser.AB.Shared.Battle
{
    public class BattleChangeSetProcessor : AbstractChangeSetProcessor
    {
        public BattleChangeSetProcessor(AttackDamageHandler attackDamageHandler, MagicDamageHandler magicDamageHandler)
        {
            RegisterHandler<AttackDamageChangeSet, AttackDamageHandler>(attackDamageHandler);
            RegisterHandler<MagicDamageChangeSet, MagicDamageHandler>(magicDamageHandler);
        }
    }
}