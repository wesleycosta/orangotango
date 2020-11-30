using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Authentication;
using Orangotango.Core.Authentication.Configurations;
using Orangotango.Core.Authentication.Interfaces;
using Orangotango.Core.Settings;
using Orangotango.Data.Context;

namespace Orangotango.DependencyInjection
{
    public static class InfrastructureConfig
    {
        internal static IServiceCollection AddInfrastructureConfig(this IServiceCollection services)
        {
            var appSettings = EnvironmentConfig.Builder();
            services.AddSingleton(appSettings);
            services.AddOrangotangoContext(appSettings.ConnectionString);
            services.AddJwtAuthConfig(appSettings);

            return services;
        }

        private static IServiceCollection AddJwtAuthConfig(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddJwtConfig(appSettings);
            services.AddScoped<IJwtAuthentication, JwtAuthentication>();

            return services;
        }


        public static IApplicationBuilder UpdateDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            serviceScope.UpdateDatabase();

            return app;
        }
    }
}
