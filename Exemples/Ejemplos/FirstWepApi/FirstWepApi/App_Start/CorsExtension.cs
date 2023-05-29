using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FirstWepApi.App_Start
{
    public static class CorsExtension
    {
        public static void EnabledCors(HttpConfiguration configuration) 
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            configuration.EnableCors(cors);
        }
    }
}