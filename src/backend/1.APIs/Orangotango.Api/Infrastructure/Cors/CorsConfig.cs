using Microsoft.Extensions.DependencyInjection;

namespace Orangotango.Api.Infrastructure.Cors
{
    public static class CorsConfig
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            // TODO
            services.AddCors(options =>
            {
                options.AddPolicy("Allow",
                     policy => policy.WithOrigins("http://localhost:4200")
                                     .AllowAnyMethod()
                                     .AllowAnyHeader()
                                     .AllowCredentials());
            });

            return services;
        }
    }
}
