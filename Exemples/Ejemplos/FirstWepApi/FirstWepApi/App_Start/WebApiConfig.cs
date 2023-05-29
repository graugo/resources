using FirstWepApi.App_Start;
using Microsoft.Web.Http.Routing;
using System.Web.Http;
using System.Web.Http.Routing;

namespace FirstWepApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            CorsExtension.EnabledCors(config);
            // Configuración y servicios de API web
            var constraintResolver = new DefaultInlineConstraintResolver
            { ConstraintMap = 
                { 
                    ["apiVersion"] = typeof(ApiVersionRouteConstraint) 
                } 
            };
            config.AddApiVersioning(options => options.ReportApiVersions = true);
            // Rutas de API web
            config.MapHttpAttributeRoutes(constraintResolver);

            config.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templatessdsd
                    options.SubstituteApiVersionInUrl = true;
                });

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
