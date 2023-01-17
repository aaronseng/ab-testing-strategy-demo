using Hanser.AB.Shared.Handlers;

namespace Hanser.AB.Shared.Factory
{
    public interface IAttackLogicFactory
    {
        public IAttackLogicHandler GetHandler();
    }
}