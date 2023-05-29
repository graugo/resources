using Autofac.Integration.WebApi;
using Autofac;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using HiveApp.ServiceLibrary.Impl.Impl;
using HiveApp.ServiceLibrary.Contracts.Contracts;
using HiveApp.Infrastructure.Contracts.Contracts;
using HiveApp.Infrastructure.Impl.Impl;
using HiveApp.WebApi.Mappers;
using HiveApp.Infrastructure.Impl.Mappers;

namespace HiveApp.WebApi.App_Start
{
    public static  class RegisterDependencies
    {
        public static void Register(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.Register(x => new HttpClient()).As<HttpClient>().SingleInstance();
            builder.RegisterInstance(LogManager.GetLogger(Assembly.GetExecutingAssembly(), Assembly.GetExecutingAssembly().GetName().Name)).SingleInstance();
            builder.RegisterType<BeeService>().As<IBeeService>().InstancePerLifetimeScope();
            builder.RegisterType<BeeRepository>().As<IBeeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ResponseMapper>().As<IResponseMapper>().InstancePerLifetimeScope();
            builder.RegisterType<RepoMapper>().As<IRepoMapper>().InstancePerLifetimeScope();
            var container = builder.Build();

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}