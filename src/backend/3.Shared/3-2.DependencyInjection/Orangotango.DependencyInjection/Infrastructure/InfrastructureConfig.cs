using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Mediator;
using Orangotango.Core.Notifications.Configurations;
using Orangotango.Core.Settings;
using Orangotango.Data.Context;
using Orangotango.MessageBus;

namespace Orangotango.DependencyInjection.Infrastructure
{
    public static class InfrastructureConfig
    {
        internal static IServiceCollection AddInfrastructureConfig(this IServiceCollection services)
        {
            services.AddMongoContext();
            services.AddNotification();
            services.AddAppSettings();
            services.AddMediator();
            services.AddAutoMapperConfig();
            services.AddMessageBus();

            return services;
        }

        private static AppSettings AddAppSettings(this IServiceCollection services)
        {
            var appSettings = EnvironmentConfig.Builder();
            services.AddSingleton(appSettings);

            return appSettings;
        }

        private static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(InfrastructureConfig));
            return services;
        }
    }
}
