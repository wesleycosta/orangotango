using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.WebApiShared.User;

namespace Orangotango.WebApiShared.Authentication.Configurations
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
