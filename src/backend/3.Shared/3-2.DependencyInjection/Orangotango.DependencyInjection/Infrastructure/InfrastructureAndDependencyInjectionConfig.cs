using Microsoft.Extensions.DependencyInjection;
using Orangotango.DependencyInjection.ConfigurationServices;

namespace Orangotango.DependencyInjection.Infrastructure
{
    public static class InfrastructureAndDependencyInjectionConfig
    {
        public static IServiceCollection ConfigureInfrastructureAndDependencyInjection(this IServiceCollection services)
        {
            services.AddInfrastructureConfig();
            services.AddRepositories();
            services.AddQueries();

            return services;
        }
    }
}
