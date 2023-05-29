using Net6CodeSample.Domain;
using System.Runtime.CompilerServices;

namespace Net6CodeSample.WebApi.Extensions
{
    public static class ConfigureExtension
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, ConfigurationManager config) 
        {
            services.Configure<SummariesEntity>(config.GetSection("SummariesEntity"));
            return services;
        }
    }
}
