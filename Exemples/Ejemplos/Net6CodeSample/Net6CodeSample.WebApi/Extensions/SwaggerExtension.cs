using Microsoft.OpenApi.Models;

namespace Net6CodeSample.WebApi.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services) 
        {
            services.AddSwaggerGen(options => 
            {
                options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme 
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "Enter Bearer Token",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement 
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }
    }
}
