using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Orangotango.Core.Swagger
{
    public static class SwaggerConfig
    {
        #region PROPERTIES

        private static readonly string AUTHENTICATION_NAME = "Authentication V1";

        #endregion

        #region AUTHENTICATION

        public static IServiceCollection AddSwaggerConfigAuth(this IServiceCollection services)
        {
            return AddSwaggerConfig(services, AUTHENTICATION_NAME);
        }

        public static IApplicationBuilder UseSwaggerConfigAuth(this IApplicationBuilder app)
        {
            return UseSwaggerConfig(app, AUTHENTICATION_NAME);
        }

        #endregion

        #region GENERIC METHODS

        private static IServiceCollection AddSwaggerConfig(this IServiceCollection services, string name)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = name, Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }

        private static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app, string name)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", name));

            return app;
        }

        #endregion
    }
}
