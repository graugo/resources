using CrossingApp.Application.ContractsInfra;
using CrossingApp.Infrastructure.Callers;
using CrossingApp.Infrastructure.Context;
using CrossingApp.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossingApp.Infrastructure.Dependencies
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICharacterRepo, CharacterRepo>();
            services.AddScoped<ITypedHttpClient, TypedHttpClient>();
            var connectionStr = configuration.GetConnectionString("CharacterDatabase");
            services.AddDbContext<CrossingContext>(
                options => options.UseSqlServer(connectionStr));
            return services;
        }
    }
}
