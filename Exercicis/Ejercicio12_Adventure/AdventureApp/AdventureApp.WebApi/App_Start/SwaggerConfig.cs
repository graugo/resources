using System.Web.Http;
using WebActivatorEx;
using AdventureApp.WebApi;
using Swashbuckle.Application;
using System;
using System.Xml.XPath;
using System.IO;
using System.Reflection;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace AdventureApp.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "AdventureApp.WebApi");

                        // Set this flag to omit descriptions for any actions decorated with the Obsolete attribute
                        //c.IgnoreObsoleteActions();

                        c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi(c =>
                    {
                        // Use the "DocumentTitle" option to change the Document title.
                        // Very helpful when you have multiple Swagger pages open, to tell them apart.
                        //
                        c.DocumentTitle("My Swagger UI");
                    });
        }

        private static string GetXmlCommentsPath()
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", xmlFile);
        }
    }
}
