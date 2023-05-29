using AdventureApp.Infrastructure.Contracts.Contracts;
using AdventureApp.Infrastructure.Impl.Cache;
using AdventureApp.Infrastructure.Impl.Configuration;
using AdventureApp.Infrastructure.Impl.Implementations;
using AdventureApp.Infrastructure.Impl.Mappers;
using AdventureApp.ServiceLibrary.Contracts.Contracts;
using AdventureApp.ServiceLibrary.Impl.Implementations;
using AdventureApp.WebApi.Mappers;
using Autofac;
using Autofac.Integration.WebApi;
using log4net;
using System.Reflection;
using System.Web.Http;

namespace AdventureApp.WebApi.App_Start
{
    public static class RegisterDependencies
    {
        public static void Register(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterType<Foo>().As<IFoo>().InstancePerLifetimeScope();

            builder.RegisterType<CharacterService>().As<ICharacterService>().InstancePerLifetimeScope();
            builder.RegisterType<CharacterMapper>().As<ICharacterMapper>().InstancePerLifetimeScope();
            builder.RegisterType<CharacterRepository>().As<ICharacterRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RepoMapper>().As<IRepoMapper>().InstancePerLifetimeScope();
            builder.RegisterType<RepoConfig>().As<IRepoConfig>().InstancePerLifetimeScope();
            builder.RegisterType<CharacterCache>().As<ICharacterCache>().InstancePerLifetimeScope();
            builder.RegisterInstance(LogManager.GetLogger(Assembly.GetExecutingAssembly(), Assembly.GetExecutingAssembly().GetName().Name)).SingleInstance();

            var container = builder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}