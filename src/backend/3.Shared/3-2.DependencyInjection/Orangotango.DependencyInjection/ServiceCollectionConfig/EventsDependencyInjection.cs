using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Business.Application.Events.Users;

namespace Orangotango.DependencyInjection.ServiceCollectionConfig
{
    internal static class EventsDependencyInjection
    {
        internal static IServiceCollection AddEvents(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<RegisteredUserEvent>, RegisteredUserHandler>();

            return services;
        }
    }
}
