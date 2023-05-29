using CrossingApp.CrossCutting.Cache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossingApp.CrossCutting.Dependecies
{
    public static class CrossCuttingModule
    {
        public static IServiceCollection AddCrosCuttingModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICrossingCache, CrossingCache>();

            // Add redis configuration
            services.AddStackExchangeRedisCache(
                options => options.Configuration = configuration["Redis:Host"]);

            return services;
        }
    }
}
