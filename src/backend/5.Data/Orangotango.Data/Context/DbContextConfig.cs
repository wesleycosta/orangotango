using Microsoft.Extensions.DependencyInjection;
using Orangotango.Business.Intefaces.Infrastructure;

namespace Orangotango.Data.Context
{
    public static class MongoContextConfig
    {
        public static IServiceCollection AddMongoContext(this IServiceCollection services)
        {
            services.AddScoped<IMongoContext, MongoContext>();
            return services;
        }
    }
}
