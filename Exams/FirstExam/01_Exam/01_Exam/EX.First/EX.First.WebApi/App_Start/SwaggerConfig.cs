using System.Web.Http;
using WebActivatorEx;
using EX.First.WebApi;
using Swashbuckle.Application;
using System;
using System.IO;
using System.Reflection;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace EX.First.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "EX.First.WebApi");
                        c.IncludeXmlComments(GetXmlPath());
                    })
                .EnableSwaggerUi();
        }

        private static string GetXmlPath()
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", xmlFile);

            return xmlPath;
        }
    }
}
