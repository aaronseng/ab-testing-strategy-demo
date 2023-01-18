using System.Text;
using Hanser.AB.Backend.Integration;
using Hanser.AB.Shared;
using Hanser.AB.Shared.Factory;

namespace Hanser.AB.Backend
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            using (var backend = serviceProvider.CreateScope())
            {
                var backendRunner = backend.ServiceProvider.GetService<BackendRunner>();
                backendRunner?.Run();
            }
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IGameEngineDataLoader>(serviceProvider => serviceProvider.GetRequiredService<BackendGameEngineDataLoader>());
            services.AddScoped<BackendGameEngineDataLoader>();
            services.AddTransient<IUserDataLoader, UserDataLoader>();
            services.AddTransient<IMonsterDataLoader, MonsterDataLoader>();
            services.AddTransient<IAttackLogicFactory, AttackLogicFactory>();
            services.AddScoped<ChangeSetProcessor>();
            services.AddScoped<WebApi>();
            services.AddScoped<BackendRunner>();
            return services;
        }
    }
}