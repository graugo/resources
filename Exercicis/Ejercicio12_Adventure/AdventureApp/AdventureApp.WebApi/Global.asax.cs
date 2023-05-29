using AdventureApp.WebApi.App_Start;
using System.Web.Http;

namespace AdventureApp.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RegisterDependencies.Register(GlobalConfiguration.Configuration);
        }
    }
}
