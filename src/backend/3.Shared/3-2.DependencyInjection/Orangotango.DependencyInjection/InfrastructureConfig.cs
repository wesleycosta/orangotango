using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Settings;
using Orangotango.Data.Context;
using Orangotango.WebApiShared.Authentication.Configurations;

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
            services.AddAspNetUser();

            return services;
        }

        private static IServiceCollection AddJwtAuthConfig(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddJwtConfig(appSettings);
            services.RegisterAuthentication();

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
