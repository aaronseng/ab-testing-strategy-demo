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

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // JsonConvert.SerializeObject(MockWebAPI.Login("John", new string[] { "User_Power_C", "Attack_Handler_Boosted" }));
            app.MapPost("/login", async context =>
            {
                using var reader = new StreamReader(context.Request.Body, Encoding.UTF8);
                var jsonObject =  await reader.ReadToEndAsync();
            });
            
            app.Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IGameEngineDataLoader, BackendGameEngineDataLoader>();
            services.AddTransient<IUserDataLoader, UserDataLoader>();
            services.AddTransient<IMonsterDataLoader, MonsterDataLoader>();
            services.AddTransient<IAttackLogicFactory, AttackLogicFactory>();
            services.AddTransient<ChangeSetProcessor>();
            services.AddScoped<BackendRunner>();
            return services;
        }
    }
}