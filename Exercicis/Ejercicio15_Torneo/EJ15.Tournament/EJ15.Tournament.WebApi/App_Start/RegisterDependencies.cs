using Autofac;
using Autofac.Integration.WebApi;
using EJ15.Tournament.Infrastructure.Contracts.Contracts;
using EJ15.Tournament.Infrastructure.Impl.Cache;
using EJ15.Tournament.Infrastructure.Impl.Caller;
using EJ15.Tournament.Infrastructure.Impl.Configuration;
using EJ15.Tournament.Infrastructure.Impl.DDBB;
using EJ15.Tournament.Infrastructure.Impl.Implementations;
using EJ15.Tournament.Infrastructure.Impl.Mapper.Pokemon;
using EJ15.Tournament.ServiceLibrary.Contracts.Contract;
using EJ15.Tournament.ServiceLibrary.Impl;
using EJ15.Tournament.ServiceLibrary.Impl.Configuration;
using EJ15.Tournament.ServiceLibrary.Impl.Implementations;
using EJ15.Tournament.WebApi.Mappers.Pokemon;
using log4net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace EJ15.Tournament.WebApi.App_Start
{
    public class RegisterDependencies
    {
        public static void Register(HttpConfiguration configuration) 
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<PokemonService>().As<IPokemonService>().InstancePerLifetimeScope();
            builder.RegisterType<PokemonMapper>().As<IPokemonMapper>().InstancePerLifetimeScope();
            builder.RegisterType<PokemonRepository>().As<IPokemonRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PokeApiMapper>().As<IPokeApiMapper>().InstancePerLifetimeScope();
            builder.RegisterType<InfrastructureConfiguration>().As<IInfrastructureConfiguration>().InstancePerLifetimeScope();
            builder.Register(x => new HttpClient()).As<HttpClient>().SingleInstance();
            builder.RegisterType<ApiCaller>().As<IApiCaller>().SingleInstance();
            builder.RegisterType<PokemonCache>().As<IPokemonCache>().SingleInstance();
            builder.RegisterType<TrainerService>().As<ITrainerService>().InstancePerLifetimeScope();
            builder.RegisterType<ServiceConfiguration>().As<IServiceConfiguration>().InstancePerLifetimeScope();
            builder.RegisterType<TrainerRepository>().As<ITrainerRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TrainerMapper>().As<ITrainerMapper>().InstancePerLifetimeScope();
            builder.RegisterInstance(LogManager.GetLogger(Assembly.GetExecutingAssembly(), Assembly.GetExecutingAssembly().GetName().Name)).SingleInstance();

            var container = builder.Build();

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}