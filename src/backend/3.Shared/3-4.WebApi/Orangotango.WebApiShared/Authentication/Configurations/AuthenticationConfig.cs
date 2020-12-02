using Microsoft.Extensions.DependencyInjection;
using Orangotango.WebApiShared.Authentication.Interfaces;

namespace Orangotango.WebApiShared.Authentication.Configurations
{
    public static class AuthenticationConfig
    {
        public static IServiceCollection RegisterAuthentication(this IServiceCollection services)
        {
            services.AddScoped<IJwtAuthentication, JwtAuthentication>();
            return services;
        }
    }
}
