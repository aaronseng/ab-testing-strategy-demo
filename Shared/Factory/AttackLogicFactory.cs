using Hanser.AB.Shared.Handlers;

namespace Hanser.AB.Shared.Factory
{
    public class AttackLogicFactory : IAttackLogicFactory
    {
        private readonly IGameEngineDataLoader _dataProvider;

        private static Dictionary<string, Func<IGameEngineDataLoader, IAttackLogicHandler>> _factoryMethods = new Dictionary<string, Func<IGameEngineDataLoader, IAttackLogicHandler>>();

        private Dictionary<string, IAttackLogicHandler> _handlers = new Dictionary<string, IAttackLogicHandler>();

        public AttackLogicFactory(IGameEngineDataLoader dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public IAttackLogicHandler GetHandler()
        {
            IAttackLogicHandler handler;

            foreach (var key in _factoryMethods.Keys)
            {
                if (TryGetHandler(key, out handler))
                {
                    return handler;
                }
            }

            // Initialize default handler if the user doesn't belong to any attack group
            if (!_handlers.TryGetValue("default", out handler))
            {
                handler = _factoryMethods["default"].Invoke(_dataProvider);
                _handlers["default"] = handler;
            }

            return handler;
        }

        private bool TryGetHandler(string key, out IAttackLogicHandler handler)
        {
            handler = null;

            if (_dataProvider.User.Groups!.Contains(key))
            {
                if (_handlers.TryGetValue(key, out handler))
                {
                    return true;
                }

                if (!_factoryMethods.ContainsKey(key))
                {
                    return false;
                }

                handler = _factoryMethods[key].Invoke(_dataProvider);
                _handlers[key] = handler;
                return true;
            }

            return false;
        }

        public static void Register(string key, Func<IGameEngineDataLoader, IAttackLogicHandler> method)
        {
            _factoryMethods.Add(key, method);
        }

        public static void Clear()
        {
            _factoryMethods.Clear();
        }
    }
}