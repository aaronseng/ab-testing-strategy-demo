using Hanser.AB.Backend.Integration;
using Hanser.AB.Shared;
using Hanser.AB.Shared.Battle;
using Hanser.AB.Shared.Systems.Battle.Handler;
using Hanser.AB.Shared.Systems.Battle.Handler.Strategy;
using Hanser.AB.Shared.Systems.Battle.Provider;

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
            services.AddScoped<ChangeSetProcessor>();
            services.AddScoped<BattleChangeSetProcessor>();
            services.AddScoped<AttackDamageHandler>();
            services.AddScoped<MagicDamageHandler>();
            services.AddTransient<IUserDataLoader, UserDataLoader>();
            services.AddTransient<IMonsterDataLoader, MonsterDataLoader>();
            services.AddScoped<WebApi>();
            services.AddScoped<BackendRunner>();

            services.AddScoped<IUserGroupProvider, UserGroupProvider>();
            services.AddScoped<IBattleStrategyProvider, BattleStrategyProvider>();
           
            services.AddScoped<DefaultAttackDamageStrategy>();
            services.AddScoped<DefaultMagicDamageStrategy>();

            services.AddScoped<IBattleHandlerStrategy>(x => x.GetRequiredService<DefaultAttackDamageStrategy>());
            services.AddScoped<IBattleHandlerStrategy>(x => x.GetRequiredService<DefaultMagicDamageStrategy>());
            services.AddScoped<IBattleHandlerStrategy, BleedAttackDamageStrategy>();
            
            return services;
        }
    }
}