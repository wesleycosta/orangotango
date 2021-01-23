using Microsoft.Extensions.DependencyInjection;
using Orangotango.DependencyInjection.ServiceCollectionConfig;

namespace Orangotango.DependencyInjection.Infrastructure
{
    public static class InfrastructureAndDependencyInjectionConfig
    {
        public static IServiceCollection ConfigureInfrastructureAndDependencyInjection(this IServiceCollection services)
        {
            services.AddInfrastructureConfig();
            services.AddServices();
            services.AddRepositories();
            services.AddCommands();
            services.AddEvents();
            services.AddQueries();

            return services;
        }
    }
}
