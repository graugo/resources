using Autofac.Integration.WebApi;
using Autofac;
using log4net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

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

            var container = builder.Build();

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}