using Microsoft.Extensions.DependencyInjection;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Data.Repository;

namespace Orangotango.DependencyInjection.ConfigurationServices
{
    internal static class RepositoriesConfig
    {
        internal static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
