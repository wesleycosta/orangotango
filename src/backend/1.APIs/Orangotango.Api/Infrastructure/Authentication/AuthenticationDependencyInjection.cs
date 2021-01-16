using Microsoft.Extensions.DependencyInjection;
using Orangotango.Api.Infrastructure.Authentication.Configurations;
using Orangotango.Core.Settings;

namespace Orangotango.Api.Infrastructure.Authentication
{
    public static class AuthenticationDependencyInjection
    {
        public static IServiceCollection AddJwtInfrastructure(this IServiceCollection services, AppSettings appSettings)
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
    }
}
