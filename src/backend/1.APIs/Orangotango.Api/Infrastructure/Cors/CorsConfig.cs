using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Settings;

namespace Orangotango.Api.Infrastructure.Cors
{
    public static class CorsConfig
    {
        private static readonly string PolicyName = "OrangotangoPolicy";

        public static IServiceCollection AddOrangotangoPolicy(this IServiceCollection services,
                                                              AppSettings appSettings)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(PolicyName,
                     policy => policy.WithOrigins(appSettings.GetOrigns())
                                     .AllowAnyMethod()
                                     .AllowAnyHeader()
                                     .AllowCredentials());
            });

            return services;
        }

        public static IApplicationBuilder UseOrangotangoPolicy(this IApplicationBuilder app)
        {
            app.UseCors(PolicyName);
            return app;
        }
    }
}
