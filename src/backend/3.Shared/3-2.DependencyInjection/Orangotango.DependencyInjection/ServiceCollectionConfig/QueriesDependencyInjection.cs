using Microsoft.Extensions.DependencyInjection;
using Orangotango.Business.Application.Queries;
using Orangotango.Business.Intefaces.Queries;

namespace Orangotango.DependencyInjection.ServiceCollectionConfig
{
    internal static class QueriesDependencyInjection
    {
        internal static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddScoped<IUserQueries, UserQueries>();

            return services;
        }
    }
}
