using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using UnitTestApp.Infrastructure.Contracts;
using UnitTestApp.Infrastructure.Impl;
using UnitTestApp.ServiceLibrary.Contracts;
using UnitTestApp.ServiceLibrary.Impl;

namespace UnitTestingApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

        //    private ISaveService _saveService;
        //    private IOrderService _orderService;
        //    private IPersistService _persistService;
        //    private IHeroRepository _heroRepository;
        //    private IHeroFileRepository _heroFileRepository;
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<SaveService>().As<ISaveService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();
            builder.RegisterType<PersistService>().As<IPersistService>().InstancePerLifetimeScope();
            builder.RegisterType<HeroRepository>().As<IHeroRepository>().SingleInstance();
            builder.Register(x => { return new HeroFileRepository("/results/Heroes.txt"); }).As<IHeroFileRepository>().SingleInstance();

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}
