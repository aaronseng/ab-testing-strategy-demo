using Hanser.AB.Shared.Handlers;

namespace Hanser.AB.Shared.Factory
{
    public class AttackLogicFactory : IAttackLogicFactory
    {
        private readonly Dictionary<string, Func<IGameEngineDataLoader, IAttackLogicHandler>> _factoryMethods = new Dictionary<string, Func<IGameEngineDataLoader, IAttackLogicHandler>>();
        private readonly Dictionary<string, IAttackLogicHandler> _handlers = new Dictionary<string, IAttackLogicHandler>();

        private readonly IGameEngineDataLoader _gameEngineDataLoader;

        public AttackLogicFactory(IGameEngineDataLoader gameEngineDataLoader)
        {
            _gameEngineDataLoader = gameEngineDataLoader;
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
                handler = _factoryMethods["default"].Invoke(_gameEngineDataLoader);
                _handlers["default"] = handler;
            }

            return handler;
        }

        private bool TryGetHandler(string key, out IAttackLogicHandler handler)
        {
            handler = null;

            if (_gameEngineDataLoader.UserDataProvider.User.Groups!.Contains(key))
            {
                if (_handlers.TryGetValue(key, out handler))
                {
                    return true;
                }

                if (!_factoryMethods.ContainsKey(key))
                {
                    return false;
                }

                handler = _factoryMethods[key].Invoke(_gameEngineDataLoader);
                _handlers[key] = handler;
                return true;
            }

            return false;
        }

        public void Register(string key, Func<IGameEngineDataLoader, IAttackLogicHandler> method)
        {
            _factoryMethods.Add(key, method);
        }
    }
}