namespace Hanser.AB.Shared.Handlers.Strategy
{
    public interface IHandlerStrategy
    {
        public IStrategyResult Handle(IStrategyResult result);

        public string Key();
    }
}