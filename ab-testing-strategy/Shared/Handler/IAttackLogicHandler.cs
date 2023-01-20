namespace Hanser.AB.Shared.Handlers
{
    public interface IAttackLogicHandler
    {
        public string Runner { get; set; }

        public void Damage(BattleChangeSet changeSet);
    }
}