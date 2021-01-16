using Microsoft.Extensions.DependencyInjection;
using Orangotango.Business.Intefaces.Infrastructure;

namespace Orangotango.Api.Infrastructure.Authentication.Configurations
{
    public static class AuthenticationConfig
    {
        public static IServiceCollection AddAuthenticationService(this IServiceCollection services)
        {
            services.AddScoped<IJwtAuthentication, JwtAuthentication>();
            return services;
        }
    }
}
