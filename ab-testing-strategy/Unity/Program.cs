using Hanser.AB.Shared;
using Hanser.AB.Shared.Battle;
using Hanser.AB.Shared.Systems.Battle.Handler;
using Hanser.AB.Shared.Systems.Battle.Handler.Strategy;
using Hanser.AB.Shared.Systems.Battle.Provider;
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
                unityRunner?.Run("Jane", new FirebaseModel() {Groups = new string[] { }});
            }

            Console.ReadLine();

            using (var unityScope = serviceProvider.CreateScope())
            {
                var unityRunner = unityScope.ServiceProvider.GetService<UnityRunner>();
                unityRunner?.Run("John", new FirebaseModel() {Groups = new string[] {"Battle_AttackDamage_Bleed"}});
            }

            Console.ReadLine();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IGameEngineDataLoader, UnityGameEngineDataLoader>();
            services.AddScoped<IUserDataLoader, UserDataLoader>();
            services.AddScoped<IMonsterDataLoader, MonsterDataLoader>();
            services.AddScoped<ChangeSetProcessor>();
            services.AddScoped<BattleChangeSetProcessor>();
            services.AddScoped<AttackDamageHandler>();
            services.AddScoped<MagicDamageHandler>();
            services.AddScoped<UnityWebClient>();
            services.AddScoped<UnityRunner>();

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