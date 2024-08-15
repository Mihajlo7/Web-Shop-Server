using ConnectionService;

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
    }
}
