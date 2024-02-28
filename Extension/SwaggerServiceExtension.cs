using Microsoft.OpenApi.Models;
using System.Runtime.CompilerServices;

namespace ProjectMarketPlace.Extension
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("1.0.0", new OpenApiInfo
                {
                    Title = "MarketPlaceService",
                    Description = "Service Backend of marketplace",
                    Version = "1.0.0",
                });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Ingrese su token jwt",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                /*
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityRequirement
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },

                        }
                    }
                });
                */
            });
            return services;
        }
    }
}
