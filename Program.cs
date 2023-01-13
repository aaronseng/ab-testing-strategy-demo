using Hanser.AB.Shared;
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
            var unityRunner = serviceProvider.GetService<UnityRunner>();

            unityRunner?.Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IGameEngineDataLoader, GameEngineDataLoader>();
            services.AddTransient<ChangeSetProcessor>();
            services.AddTransient<GameEngine>();
            services.AddSingleton<UnityRunner>();
            return services;
        }
    }
}