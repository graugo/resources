using System.Web.Http;
using WebActivatorEx;
using HiveApp.WebApi3;
using Swashbuckle.Application;
using System.Web.Http.Description;
using System.IO;
using System.Reflection;
using System;
using Swashbuckle.Swagger;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace HiveApp.WebApi3
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
                     

                     c.MultipleApiVersions(
                        (apiDesc, targetApiVersion) => ResolveVersionSupportByRouteConstraint(apiDesc, targetApiVersion),
                        (vc) =>
                        {
                            vc.Version("V1", "HiveApp.WebApi3 V1");
                        });

                     var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                     var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", xmlFile);
                     c.IncludeXmlComments(xmlPath);
                     //c.IncludeXmlComments(@"C:\Users\Admin\Source\Repos\TestWebApi\TestWebApi.WebApi\bin\TestWebApi.WebApi.xml");

                     c.MapType<int?>(() => new Schema { type = "integer, null", format = "int32", @default = 0 });
                     //c.MapType<decimal?>(() => new Schema { type = "decimal, null", format = "double", @default = 0.0 });
                     //c.MapType<bool?>(() => new Schema { type = "boolean, null", @default = false });
                     //c.MapType<TimeSpan?>(() => new Schema { type = "string, null", @default = "00:00:00" });
                     //c.MapType<TimeSpan>(() => new Schema { type = "string, null", @default = "00:00:00" });
                     //c.MapType<byte>(() => new Schema { type = "byte", @default = 0 });
                     //c.MapType<byte?>(() => new Schema { type = "byte, null", @default = 0 });
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
