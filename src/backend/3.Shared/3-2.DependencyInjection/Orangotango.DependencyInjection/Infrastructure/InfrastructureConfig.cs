using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Mediator;
using Orangotango.Core.Notifications.Configurations;
using Orangotango.Core.Settings;
using Orangotango.Data.Context;
using Orangotango.DependencyInjection.Infrastructure;
using Orangotango.WebApiShared.Authentication.Configurations;

namespace Orangotango.DependencyInjection.Infrastructure
{
    public static class InfrastructureConfig
    {
        internal static IServiceCollection AddInfrastructureConfig(this IServiceCollection services)
        {
            var appSettings = services.AddAppSettings();
            services.AddOrangotangoContext(appSettings.ConnectionString);

            services.AddJwtnfrastructure(appSettings);

            services.AddNotification();
            services.AddMediator();
            services.AddAutoMapperConfig();

            return services;
        }

        private static AppSettings AddAppSettings(this IServiceCollection services)
        {
            var appSettings = EnvironmentConfig.Builder();
            services.AddSingleton(appSettings);

            return appSettings;
        }

        private static IServiceCollection AddJwtnfrastructure(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddJwtAuthConfig(appSettings);
            services.AddAspNetUser();

            return services;
        }

        private static IServiceCollection AddJwtAuthConfig(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddJwtConfig(appSettings);
            services.AddAuthenticationService();

            return services;
        }

        private static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(InfrastructureConfig));
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
