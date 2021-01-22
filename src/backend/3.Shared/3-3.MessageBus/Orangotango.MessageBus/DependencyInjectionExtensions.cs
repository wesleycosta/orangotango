using System;
using Microsoft.Extensions.DependencyInjection;

namespace Orangotango.MessageBus
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
        {
            if (string.IsNullOrEmpty(connection))
                throw new ArgumentNullException();

            return services;
        }
    }
}