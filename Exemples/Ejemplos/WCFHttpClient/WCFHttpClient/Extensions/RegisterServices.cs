using Autofac.Integration.Wcf;
using Autofac;
using System.Net.Http;
using WCFHttpClient.Infrastructure.Contracts.Contracts;
using WCFHttpClient.Infrastructure.Contracts.Mappers;
using WCFHttpClient.Infrastructure.Impl;
using WCFHttpClient.Mappers;
using WCFHttpClient.ServiceLibrary.Contracts.Contracts;
using WCFHttpClient.ServiceLibrary.Impl.Implementations;
using log4net;
using System.Reflection;
using WCFHttpClient.Infrastructure.Impl.Configuration;

namespace WCFHttpClient.Extensions
{
    public static class RegisterServices
    {
        public static void Register() 
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Service1>().As<IService1>().InstancePerLifetimeScope();
            builder.Register(x => new HttpClient()).As<HttpClient>().SingleInstance();
            builder.RegisterType<PokemonService>().As<IPokemonService>().InstancePerLifetimeScope();
            builder.RegisterType<Mapper>().As<IMapper>().InstancePerLifetimeScope();
            builder.RegisterType<PokemonRetrieveService>().As<IPokemonRetrieveService>().InstancePerLifetimeScope();
            builder.RegisterType<PokemonRepository>().As<IPokemonRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RepositoryMapper>().As<IRepositoryMapper>().InstancePerLifetimeScope();
            builder.RegisterInstance(LogManager.GetLogger(Assembly.GetExecutingAssembly(), Assembly.GetExecutingAssembly().GetName().Name)).SingleInstance();
            builder.RegisterType<RepositoryConfiguration>().As<IRepositoryConfiguration>().InstancePerLifetimeScope();
            
            var container = builder.Build();

            AutofacHostFactory.Container = container;
        }
    }
}