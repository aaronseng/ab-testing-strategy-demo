using Hanser.AB.Shared;
using Hanser.AB.Shared.Factory;
using Hanser.AB.Unity;
using Microsoft.Extensions.DependencyInjection;

namespace Hanser.AB
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            using (var unityScope = serviceProvider.CreateScope())
            {
                var unityRunner = unityScope.ServiceProvider.GetService<UnityRunner>();
                unityRunner?.Run();
            }
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IGameEngineDataLoader, GameEngineDataLoader>();
            services.AddTransient<IAttackLogicFactory, AttackLogicFactory>();
            services.AddTransient<ChangeSetProcessor>();
            services.AddSingleton<UnityRunner>();
            return services;
        }
    }
}