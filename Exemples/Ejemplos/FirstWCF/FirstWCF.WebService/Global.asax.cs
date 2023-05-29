using Autofac;
using Autofac.Integration.Wcf;
using FirstWCF.WebService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace FirstWCF.WebService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Service1>().As<IService1>().InstancePerLifetimeScope();
            builder.RegisterType<FooService>().As<IFooService>().InstancePerLifetimeScope();

            var container = builder.Build();

            AutofacHostFactory.Container = container;
        }
    }
}