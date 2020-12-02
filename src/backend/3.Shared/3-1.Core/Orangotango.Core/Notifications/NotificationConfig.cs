using Microsoft.Extensions.DependencyInjection;

namespace Orangotango.Core.Notifications
{
    public static class NotificationConfig
    {
        public static IServiceCollection AddNotification(this IServiceCollection services)
        {
            services.AddScoped<INotifier, Notifier>();
            return services;
        }
    }
}
