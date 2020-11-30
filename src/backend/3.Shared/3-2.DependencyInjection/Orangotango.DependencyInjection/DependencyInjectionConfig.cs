using Microsoft.Extensions.DependencyInjection;

namespace Orangotango.DependencyInjection
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ConfigureInfrastructureAndDependencyInjection(this IServiceCollection services)
        {
            services.AddInfrastructureConfig();

            return services;
        }
    }
}
