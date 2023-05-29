using Ejercicio19_Subasta.Application.Contracts;
using Ejercicio19_Subasta.Application.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Ejercicio19_Subasta.Application.Dependencies
{
    public static class ApplicationServiceModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<IBidService, BidService>();
            services.AddScoped<IHistoryService, HistoryService>();
            services.AddScoped<IAuctionService, AuctionService>();
            services.AddScoped<ITransactionService, TransactionService>();

            return services;
        }
    }
}
