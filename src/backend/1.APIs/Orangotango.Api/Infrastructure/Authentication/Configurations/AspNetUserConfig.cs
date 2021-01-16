using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Api.Infrastructure.Authentication.User;

namespace Orangotango.Api.Infrastructure.Authentication.Configurations
{
    public static class AspNetUserConfig
    {
        public static IServiceCollection AddAspNetUser(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            return services;
        }
    }
}
