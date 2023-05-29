using Autofac.Integration.WebApi;
using Autofac;
using FirstWepApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace FirstWepApi.App_Start
{
    public static class RegisterDependencies
    {
        public static void Register(HttpConfiguration configuration) 
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<FooService>().As<IFooService>().InstancePerLifetimeScope();

            var container = builder.Build();

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}