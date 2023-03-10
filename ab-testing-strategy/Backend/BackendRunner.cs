using Hanser.AB.Backend.Integration;
using Hanser.AB.Shared;
using Hanser.AB.Shared.Systems.Battle.Handler.Strategy;
using Hanser.AB.Util;

namespace Hanser.AB.Backend
{
    public class BackendRunner
    {
        private readonly BackendGameEngineDataLoader _gameEngineDataLoader;
        private readonly ChangeSetProcessor _changeSetProcessor;
        private readonly WebApi _webApi;

        public BackendRunner(IEnumerable<IBattleHandlerStrategy> strategies, ChangeSetProcessor changeSetProcessor, BackendGameEngineDataLoader gameEngineDataLoader, WebApi webApi)
        {
            _gameEngineDataLoader = gameEngineDataLoader;
            _changeSetProcessor = changeSetProcessor;
            _webApi = webApi;

            Logger.Runner = nameof(BackendRunner);
        }

        public void Run()
        {
            Console.WriteLine($"{Environment.NewLine}# INITIALIZING BACKEND ENVIRONMENT #");

            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();

            app.MapPost("/login", _webApi.Login);
            app.MapPost("/getMonster", _webApi.GetGoblin);
            app.MapPost("/sendChangeSet", _webApi.SendChangeSet);
            
            app.Run();

        }
    }
}