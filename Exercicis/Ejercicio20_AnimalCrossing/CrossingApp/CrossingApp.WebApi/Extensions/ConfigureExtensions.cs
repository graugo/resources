using CrossingApp.Infrastructure.Models.Config;

namespace CrossingApp.WebApi.Extensions
{
    public static class ConfigureExtensions
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, ConfigurationManager config)
        {
            services.Configure<URLConfig>(config.GetSection("Urls"));
            return services;
        }
    }
}
