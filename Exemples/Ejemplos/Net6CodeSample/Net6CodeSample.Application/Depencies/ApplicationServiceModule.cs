using Microsoft.Extensions.DependencyInjection;
using Net6CodeSample.Application.Contracts;
using Net6CodeSample.Application.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6CodeSample.Application.Depencies
{
    public static class ApplicationServiceModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services) 
        {
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            return services;
        }
    }
}
