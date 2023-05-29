using Autofac;
using Autofac.Integration.WebApi;
using EX.First.Infrastructure.Contracts;
using EX.First.Infrastructure.Contracts.Contracts;
using EX.First.Infrastructure.Impl.Cache;
using EX.First.Infrastructure.Impl.Caller;
using EX.First.Infrastructure.Impl.Configuration;
using EX.First.Infrastructure.Impl.Implementations;
using EX.First.Infrastructure.Impl.Mappers;
using EX.First.ServiceLibrary.Contracts.Contracts;
using EX.First.ServiceLibrary.Impl.Implementations;
using EX.First.WebApi.Mapper;
using log4net;
using StackExchange.Redis;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace EX.First.WebApi.App_Start 
{
    public class RegisterDependencies
    {
        public static void Register(HttpConfiguration config) 
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<RouteService>().As<IRouteService>().InstancePerLifetimeScope(); 
            builder.RegisterInstance(LogManager.GetLogger(Assembly.GetExecutingAssembly(), Assembly.GetExecutingAssembly().GetName().Name)).SingleInstance();
            builder.Register(x => new HttpClient()).As<HttpClient>().SingleInstance();
            builder.RegisterType<ApiCaller>().As<IApiCaller>().InstancePerLifetimeScope();
            builder.RegisterType<SindicateRepository>().As<ISindicateRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SindicateMapper>().As<ISindicateMapper>().InstancePerLifetimeScope();
            builder.RegisterType<InfrastructureConfiguration>().As<IInfrastructureConfiguration>().InstancePerLifetimeScope();
            builder.RegisterType<RouteMapper>().As<IRouteMapper>().InstancePerLifetimeScope();
            builder.RegisterType<EmpireRepository>().As<IEmpireRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EmpireMapper>().As<IEmpireMapper>().InstancePerLifetimeScope();
            builder.RegisterType<CacheService>().As<ICacheService>().InstancePerLifetimeScope();
            builder.RegisterType<RedisCacheService>().As<IRedisCacheService>().InstancePerLifetimeScope();
            builder.Register<IConnectionMultiplexer>(x => ConnectionMultiplexer.Connect("localhost")).SingleInstance();
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}