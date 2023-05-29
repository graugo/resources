using CrossingApp.Application.Contracts;
using CrossingApp.Application.Impl;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingApp.Application.Dependencies
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<ICharacterService, CharacterService>();
            return services;
        }
    }
}
