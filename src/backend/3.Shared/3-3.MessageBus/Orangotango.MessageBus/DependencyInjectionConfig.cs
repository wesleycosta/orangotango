using Microsoft.Extensions.DependencyInjection;
using Orangotango.MessageBus.RabbitMQ;

namespace Orangotango.MessageBus
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services)
        {
            services.AddScoped<IMessageBus, RabbitMQBus>();
            return services;
        }
    }
}