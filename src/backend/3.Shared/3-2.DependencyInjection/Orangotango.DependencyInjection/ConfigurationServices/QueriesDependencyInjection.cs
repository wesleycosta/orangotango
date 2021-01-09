using Microsoft.Extensions.DependencyInjection;
using Orangotango.Business.Intefaces.Queries;
using Orangotango.Business.Queries;

namespace Orangotango.DependencyInjection.ConfigurationServices
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
