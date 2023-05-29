using System.Web.Http;
using WebActivatorEx;
using HiveApp.WebApi;
using Swashbuckle.Application;
using System.IO;
using System.Reflection;
using System;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace HiveApp.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "EJ15.Hive.WebApi");
                    c.IncludeXmlComments(GetXMLPath());
                })
                .EnableSwaggerUi(c =>
                {
                    c.DocumentTitle("Hive Simulation API");
                    c.DocExpansion(DocExpansion.Full);
                });
        }

        private static string GetXMLPath()
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", xmlFile);

            return xmlPath;
        }
    }
}
