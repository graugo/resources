using System.Web.Http;
using WebActivatorEx;
using HiveApp.WebApi;
using Swashbuckle.Application;
using System.Web.Http.Description;
using System;
using System.IO;
using System.Reflection;
using Swashbuckle.Swagger;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace HiveApp.WebApi
{
#pragma warning disable CS1591
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "HiveApp.WebApi");

                        //c.MultipleApiVersions(
                        //    (apiDesc, targetApiVersion) => ResolveVersionSupportByRouteConstraint(apiDesc, targetApiVersion),
                        //    (vc) =>
                        //    {
                        //        vc.Version("v1", "Swashbuckle Dummy API V1");
                        //    });
                        
                        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                        var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", xmlFile);
                        c.IncludeXmlComments(xmlPath);
                        
                        // Set this flag to omit descriptions for any actions decorated with the Obsolete attribute
                        //c.IgnoreObsoleteActions
                       
                        // If you annotate Controllers and API Types with
                        // Xml comments (http://msdn.microsoft.com/en-us/library/b2s063f7(v=vs.110).aspx), you can incorporate
                        // those comments into the generated docs and UI. You can enable this by providing the path to one or
                        // more Xml comment files.
                        //
                        //c.IncludeXmlComments(GetXmlCommentsPath());

                        c.MapType<int?>(() => new Schema { type = "integer", format = "int32" });
                    })
                .EnableSwaggerUi();
        }

        private static bool ResolveVersionSupportByRouteConstraint(ApiDescription apiDesc, string targetApiVersion)
        {
            return apiDesc.ActionDescriptor.ControllerDescriptor.ControllerType.FullName.Contains($"{targetApiVersion}");
        }
    }
#pragma warning restore CS1591
}
