using Autofac.Integration.WebApi;
using Autofac;
using log4net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using Exam.RouteApp.ServiceLibrary.Impl.Implementations;
using Exam.RouteApp.ServiceLibrary.Contracts.Contracts;
using Exam.RouteApp.Infrastructure.Contracts.Contracts;
using Exam.RouteApp.Infrastructure.Impl.Implementations;
using Exam.RouteApp.Infrastructure.Impl.Caller;
using Exam.RouteApp.Infrastructure.Impl.Config;
using Exam.RouteApp.Infrastructure.Impl.Mapper;
using Exam.RouteApp.Infrastructure.Impl.Cache;
using Exam.RouteApp.WebApi.Mappers;

namespace Exam.RouteApp.WebApi.App_Start
{
    public static class RegisterDependencies
    {
        public static void Register(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
           
            builder.Register(x => new HttpClient()).As<HttpClient>().SingleInstance();
            builder.RegisterInstance(LogManager.GetLogger(Assembly.GetExecutingAssembly(), Assembly.GetExecutingAssembly().GetName().Name)).SingleInstance();
            builder.RegisterType<RouteService>().As<IRouteService>().InstancePerLifetimeScope();
            builder.RegisterType<RouteRepository>().As<IRouteRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ApiCaller>().As<IApiCaller>().SingleInstance();
            builder.RegisterType<RepoConfig>().As<IRepoConfig>().InstancePerLifetimeScope();
            builder.RegisterType<RepoMapper>().As<IRepoMapper>().InstancePerLifetimeScope();
            builder.RegisterType<RepoCache>().As<IRepoCache>().SingleInstance();
            builder.RegisterType<Mapper>().As<IMapper>().InstancePerLifetimeScope();

            var container = builder.Build();

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}