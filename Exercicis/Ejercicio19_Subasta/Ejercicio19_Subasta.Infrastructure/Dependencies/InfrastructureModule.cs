using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Ejercicio19_Subasta.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Ejercicio19_Subasta.Application.InfrastructureContracts;
using Ejercicio19_Subasta.Infrastructure.Implementation;
using Ejercicio19_Subasta.Infrastructure.Callers;

namespace Ejercicio19_Subasta.Infrastructure.Dependencies
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPokemonRepository, PokemonRepository>();
            services.AddScoped<ITypedHttpClient, TypedHttpClient>();
            services.AddScoped<IBidRepository, BidRepository>();
            services.AddScoped<IHistoryRepository, HistoryRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddDbContext<AuctionDBContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("AuctionDB")), ServiceLifetime.Singleton);

            return services;
        }
    }
}
