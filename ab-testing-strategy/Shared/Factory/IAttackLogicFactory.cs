using Hanser.AB.Shared.Handlers;

namespace Hanser.AB.Shared.Factory
{
    public interface IAttackLogicFactory
    {
        public IAttackLogicHandler GetHandler();

        public void Register(string key, Func<IGameEngineDataLoader, IAttackLogicHandler> method);
    }
}