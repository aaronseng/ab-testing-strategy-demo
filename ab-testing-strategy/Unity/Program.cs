using Hanser.AB.Shared;
using Hanser.AB.Shared.Factory;
using Hanser.AB.Unity;
using Microsoft.Extensions.DependencyInjection;

namespace Hanser.AB
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

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

            Console.ReadLine();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IGameEngineDataLoader, UnityGameEngineDataLoader>();
            services.AddTransient<IUserDataLoader, UserDataLoader>();
            services.AddTransient<IMonsterDataLoader, MonsterDataLoader>();
            services.AddTransient<IAttackLogicFactory, AttackLogicFactory>();
            services.AddTransient<ChangeSetProcessor>();
            services.AddScoped<UnityRunner>();
            return services;
        }
    }
}