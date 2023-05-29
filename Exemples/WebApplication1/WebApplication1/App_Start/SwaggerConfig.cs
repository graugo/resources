using System.Web.Http;
using WebActivatorEx;
using WebApplication1;
using Swashbuckle.Application;
using System.Web.Http.Description;
using System;
using System.Reflection;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApplication1
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        
                        c.MultipleApiVersions(
                            (apiDesc, targetApiVersion) => ResolveVersionSupportByRouteConstraint(apiDesc, targetApiVersion),
                            (vc) =>
                            {
                                vc.Version("v2", "Swashbuckle Dummy API V2");
                                vc.Version("v1", "Swashbuckle Dummy API V1");
                            });

                        // Set this flag to omit descriptions for any actions decorated with the Obsolete attribute
                        //c.IgnoreObsoleteActions();

                        // If you annotate Controllers and API Types with
                        // Xml comments (http://msdn.microsoft.com/en-us/library/b2s063f7(v=vs.110).aspx), you can incorporate
                        // those comments into the generated docs and UI. You can enable this by providing the path to one or
                        // more Xml comment files.
                        //
                        //c.IncludeXmlComments(GetXmlCommentsPath());

                        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                        var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", xmlFile);
                        c.IncludeXmlComments(xmlPath);
                    })
                .EnableSwaggerUi();
        }

        private static bool ResolveVersionSupportByRouteConstraint(ApiDescription apiDesc, string targetApiVersion)
        {
            return apiDesc.ActionDescriptor.ControllerDescriptor.ControllerType.FullName.Contains($"{targetApiVersion}");
        }
    }
}
