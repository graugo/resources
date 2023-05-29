using Autofac;
using Autofac.Integration.WebApi;
using HiveApp.Infrastructure.Contracts.Contracts;
using HiveApp.Infrastructure.Contracts.Mappers;
using HiveApp.Infrastructure.Impl.Config;
using HiveApp.Infrastructure.Impl.Implementations;
using HiveApp.ServiceLibrary.Contracts.Contracts;
using HiveApp.ServiceLibrary.Impl;
using HiveApp.ServiceLibrary.Impl.Implementations;
using System.Reflection;
using System.Web.Http;

namespace HiveApp.WebApi.App_Start
{
    public class RegisterDependencies
    {
        public static void Register(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Domain dependencies
            builder.RegisterType<BeeUpdateService>().As<IBeeUpdateService>().InstancePerLifetimeScope();
            builder.RegisterType<BeeDeleteService>().As<IBeeDeleteService>().InstancePerLifetimeScope();
            builder.RegisterType<BeeCreateService>().As<IBeeCreateService>().InstancePerLifetimeScope();
            builder.RegisterType<BeeFilterService>().As<IBeeFilterService>().InstancePerLifetimeScope();

            //Infrastucture dependecies
            builder.RegisterType<HiveRepository>().As<IHiveRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RepositoryMapper>().As<IRepositoryMapper>().InstancePerLifetimeScope();
            builder.RegisterType<RepositoryConfiguration>().As<IRepositoryConfiguration>().InstancePerLifetimeScope();

            var container = builder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}