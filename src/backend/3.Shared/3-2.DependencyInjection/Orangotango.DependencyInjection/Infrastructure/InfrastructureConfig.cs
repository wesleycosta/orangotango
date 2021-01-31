using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Business.Configurations.AutoMapper;
using Orangotango.Core.Mediator;
using Orangotango.Core.Notifications.Configurations;
using Orangotango.Data.Context;
using Orangotango.MessageBus;

namespace Orangotango.DependencyInjection.Infrastructure
{
    public static class InfrastructureConfig
    {
        internal static IServiceCollection AddInfrastructureConfig(this IServiceCollection services)
        {
            services.AddAppSettings();
            services.AddMongoContext();

            services.AddAutoMapper();
            services.AddNotification();
            services.AddMediator();
            services.AddMessageBus();

            return services;
        }

        private static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
            return services;
        }

        private static IServiceCollection AddAppSettings(this IServiceCollection services)
        {
            var appSettings = EnvironmentConfig.Builder();
            services.AddSingleton(appSettings);

            return services;
        }
    }
}
