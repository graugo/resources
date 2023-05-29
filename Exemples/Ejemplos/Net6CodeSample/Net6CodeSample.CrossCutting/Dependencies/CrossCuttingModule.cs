using Microsoft.Extensions.DependencyInjection;
using Net6CodeSample.CrossCutting.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6CodeSample.CrossCutting.Dependencies
{
    public static class CrossCuttingModule
    {
        public static IServiceCollection AddCrosCuttingModule(this IServiceCollection services) 
        {
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IRedisCacheService, RedisCacheService>();

            return services;
        }
    }
}
