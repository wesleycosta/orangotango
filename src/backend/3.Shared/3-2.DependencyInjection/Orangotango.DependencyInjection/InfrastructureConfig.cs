using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Settings;
using Orangotango.Data.Context;

namespace Orangotango.DependencyInjection
{
    internal static class InfrastructureConfig
    {
        public static IServiceCollection AddInfrastructureConfig(this IServiceCollection services)
        {
            var appSettings = new AppSettings
            {
                ConnectionString = ""
            };

            services.AddSingleton(appSettings);
            services.AddOrangotangoContext(appSettings.ConnectionString);

            return services;
        }
    }
}
