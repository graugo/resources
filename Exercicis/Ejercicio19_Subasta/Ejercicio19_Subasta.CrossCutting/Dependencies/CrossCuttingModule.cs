using Ejercicio19_Subasta.CrossCutting.Cache;
using Ejercicio19_Subasta.CrossCutting.Redis;
using Microsoft.Extensions.DependencyInjection;

namespace Ejercicio19_Subasta.CrossCutting.Dependencies
{
    public static class CrossCuttingModule
    {
        public static IServiceCollection AddCrosCuttingModule(this IServiceCollection services)
        {
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IRedisCache, RedisCache>();

            return services;
        }
    }
}
