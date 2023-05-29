using Ejercicio19_Subasta.Application.InfrastructureContracts;
using Ejercicio19_Subasta.CrossCutting.Cache;
using Ejercicio19_Subasta.CrossCutting.Redis;
using Ejercicio19_Subasta.Infrastructure.Callers;
using Ejercicio19_Subasta.Infrastructure.Context;
using Ejercicio19_Subasta.Infrastructure.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using RedisCache = Ejercicio19_Subasta.CrossCutting.Redis.RedisCache;

namespace Ejercicio19_Subasta.Infrastructure.IntegrationTest.IOC
{
    public static class InfrastructureTestingModule
    {
        private const string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=AuctionDB;Trusted_Connection=True";
        public static IServiceCollection AddInfrastructureTestingModule()
        {
            IServiceCollection services = new ServiceCollection();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IPokemonRepository, PokemonRepository>();
            services.AddScoped<IBidRepository, BidRepository>();
            services.AddScoped<IHistoryRepository, HistoryRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddLogging();
            services.AddScoped<ICacheService, CacheService>();
            
            services.AddHttpClient<ITypedHttpClient, TypedHttpClient>(client =>
            {
                client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            });

            services.AddScoped<IRedisCache, RedisCache>();
            var redisAction = new Action<RedisCacheOptions>(x =>
            {
                x.Configuration = "localhost:6379";
            });
            services.AddStackExchangeRedisCache(redisAction);
            services.AddMemoryCache();
            services.AddDbContext<AuctionDBContext>(options => options.UseSqlServer(_connectionString));

            return services;
        }
    }
}
