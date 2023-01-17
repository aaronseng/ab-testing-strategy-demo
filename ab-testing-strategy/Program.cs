using Hanser.AB.Backend;
using Hanser.AB.Backend.Integration;
using Hanser.AB.Shared;
using Hanser.AB.Shared.Factory;
using Hanser.AB.Unity;
using Microsoft.Extensions.DependencyInjection;

namespace Hanser.AB
{
    public static class Program
    {
        public delegate IGameEngineDataLoader GameEngineDataServiceResolver(string key);
        
        public static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            using (var backendScope = serviceProvider.CreateScope())
            {
                var backendRunner = backendScope.ServiceProvider.GetService<BackendRunner>();
                backendRunner?.Run();
            }

            using (var unityScope = serviceProvider.CreateScope())
            {
                var unityRunner = unityScope.ServiceProvider.GetService<UnityRunner>();
                unityRunner?.Run("Jane", new FirebaseModel() { Groups = new string[] { } });
            }

            using (var unityScope = serviceProvider.CreateScope())
            {
                var unityRunner = unityScope.ServiceProvider.GetService<UnityRunner>();
                unityRunner?.Run("John", new FirebaseModel() { Groups = new string[] { "Goblin_Config_B", "User_Power_C", "Attack_Handler_Boosted" } });
            }
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<UnityGameEngineDataLoader>();
            services.AddTransient<BackendGameEngineDataLoader>();
            
            services.AddTransient<GameEngineDataServiceResolver>(serviceProvider => key =>
            {
                switch (key)
                {
                    case "Unity":
                        return serviceProvider.GetService<UnityGameEngineDataLoader>();
                    case "Backend":
                        return serviceProvider.GetService<BackendGameEngineDataLoader>();
                    default:
                        throw new KeyNotFoundException();
                }
            });
            services.AddTransient<IAttackLogicFactory, AttackLogicFactory>();
            services.AddTransient<ChangeSetProcessor>();
            services.AddScoped<UnityRunner>();
            services.AddSingleton<BackendRunner>();
            return services;
        }
    }
}