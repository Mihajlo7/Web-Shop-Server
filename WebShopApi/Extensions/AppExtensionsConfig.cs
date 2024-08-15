using App.Infrastructure;
using ConnectionService;
using Person.Mediator;

namespace WebShopApi.Extensions
{
    public static class AppExtensionsConfig
    {
        public static IHostBuilder ConfigDatabaseConnection(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("Secret/database.secret.json", optional: true, reloadOnChange: true);
            });
            return hostBuilder;

        }
        public static IServiceCollection ConfigConnectionService(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionService,ConnectionServiceImp>();
            return services;
        }
        public static IServiceCollection ConfigAppDbContext(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            return services;
        }
        public static IServiceCollection ConfigPersonsDI(this IServiceCollection services)
        {
            services.AddPersonMediator();
            services.AddPersonRepository();
            return services;
        }
    }
}
