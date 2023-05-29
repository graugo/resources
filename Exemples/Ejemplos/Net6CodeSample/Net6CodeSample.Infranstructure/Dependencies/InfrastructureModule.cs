using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net6CodeSample.Application.InfrastructureContracts;
using Net6CodeSample.Infranstructure.Callers;
using Net6CodeSample.Infranstructure.Context;
using Net6CodeSample.Infranstructure.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6CodeSample.Infranstructure.Dependencies
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<IWeatherRepository, WeatherRepository>();
            services.AddScoped<TypedHttpClient>();
            services.AddDbContext<WeatherDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("WeatherDb")));

            return services;
        }
    }
}
