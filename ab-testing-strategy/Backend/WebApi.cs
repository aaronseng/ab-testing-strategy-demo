using System.Text;
using Hanser.AB.Backend.Integration;
using Hanser.AB.Shared;
using Hanser.AB.Util;
using Newtonsoft.Json;

namespace Hanser.AB.Backend
{
    public class WebApi
    {
        private readonly ChangeSetProcessor _changeSetProcessor;
        private readonly BackendGameEngineDataLoader _gameEngineDataLoader;

        public WebApi(BackendGameEngineDataLoader gameEngineDataLoader, ChangeSetProcessor changeSetProcessor)
        {
            _changeSetProcessor = changeSetProcessor;
            _gameEngineDataLoader = gameEngineDataLoader;
        }
        
        /// <summary>
        /// Returns the user
        /// </summary>
        /// <returns>User</returns>
        public async void Login(HttpContext context)
        {
            using var reader = new StreamReader(context.Request.Body, Encoding.UTF8);
            var content =  await reader.ReadToEndAsync();
            var loginRequest = JsonConvert.DeserializeObject<LoginRequest>(content);

            var user = MockDatabase.GetUser(loginRequest.Name, loginRequest.Groups);

            await context.Response.WriteAsync(JsonConvert.SerializeObject(user));
        }

        /// <summary>
        /// Returns a goblin
        /// </summary>
        /// <returns>Goblin</returns>
        public async void GetGoblin(HttpContext context)
        {
            using var reader = new StreamReader(context.Request.Body, Encoding.UTF8);
            var content =  await reader.ReadToEndAsync();
            var monsterRequest = JsonConvert.DeserializeObject<MonsterRequest>(content);

            var monster = MockDatabase.SelectGoblin(monsterRequest.Groups);

            await context.Response.WriteAsync(JsonConvert.SerializeObject(monster));
        }

        /// <summary>
        /// Receives an AttackChangeSet and pass it to the ChangeSetProcessor
        /// </summary>
        /// <param name="context"></param>
        public async void SendChangeSet(HttpContext context)
        {
            using var reader = new StreamReader(context.Request.Body, Encoding.UTF8);
            var content =  await reader.ReadToEndAsync();
            var changeSetRequest = JsonConvert.DeserializeObject<ChangeSetRequest>(content, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });

            var changeSet = changeSetRequest.ChangeSet;

            Logger.Log("WebAPI", $"Received ChangeSet [{changeSet.GetType().Name}]", true, ConsoleColor.DarkMagenta);

            _gameEngineDataLoader.UserDataProvider.LoadUser(changeSetRequest.Player);
            // TODO: Auto switch the context whenever a User loaded 
            _gameEngineDataLoader.SwitchContext();
            _changeSetProcessor.Process(changeSet);
        }
    }
}