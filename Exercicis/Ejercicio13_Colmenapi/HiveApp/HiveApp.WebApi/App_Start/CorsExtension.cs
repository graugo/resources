using System.Web.Http;
using System.Web.Http.Cors;

namespace HiveApp.WebApi.App_Start
{
    public static class CorsExtension
    {
        internal static void EnabledCors(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }
    }
}