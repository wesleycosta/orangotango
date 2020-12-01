using Microsoft.Extensions.DependencyInjection;

namespace Orangotango.DependencyInjection
{
    public static class InfrastructureAndDependencyInjectionConfig
    {
        public static IServiceCollection ConfigureInfrastructureAndDependencyInjection(this IServiceCollection services)
        {
            services.AddInfrastructureConfig();

            return services;
        }
    }
}
