using Hanser.AB.Shared.Handlers;

namespace Shared.Handler.Strategy
{
    public class BasicStrategyResult : IStrategyResult
    {
        public static readonly BasicStrategyResult True = new BasicStrategyResult() { Result = true };
        public static readonly BasicStrategyResult False = new BasicStrategyResult() { Result = false };

        public bool Result { get; set; }
    }
}