using Microsoft.Extensions.DependencyInjection;
using Orangotango.Business.Application.Events.Users;
using Orangotango.Business.Intefaces.Services;
using Orangotango.Business.Services;
using Orangotango.Core.Services;

namespace Orangotango.DependencyInjection.ServiceCollectionConfig
{
    internal static class ServicesDependencyInjection
    {
        internal static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IQueueFactory, QueueFactory>();
            services.AddScoped<IEmailIntegrationHandler, EmailIntegrationHandler>();
            services.AddScoped<ILoggerService, LoggerService>();

            return services;
        }
    }
}
