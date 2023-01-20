using Hanser.AB.Shared.Handlers.Strategy;

namespace Shared.Handler.Strategy
{
    public interface IStrategyProvider
    {
        public HashSet<IHandlerStrategy> Provide<T>(IHandlerStrategy defaultStrategy);

        public void Register<T>(IHandlerStrategy strategy);
    }
}