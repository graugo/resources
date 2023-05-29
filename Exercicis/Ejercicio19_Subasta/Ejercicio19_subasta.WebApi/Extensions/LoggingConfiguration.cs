using Serilog;

namespace Ejercicio19_subasta.WebApi.Extensions
{
    public static class LoggingConfiguration
    {
        public static ConfigureHostBuilder AddLoggingConfig(this ConfigureHostBuilder services)
        {
            services.UseSerilog((context, services, config) =>
                config.ReadFrom.Configuration(context.Configuration).
                ReadFrom.Services(services));

            return services;
        }
    }
}
