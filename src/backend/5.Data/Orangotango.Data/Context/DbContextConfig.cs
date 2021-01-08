using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using Orangotango.Business.Intefaces.Infrastructure;

namespace Orangotango.Data.Context
{
    public static class MongoContextConfig
    {
        public static IServiceCollection AddMongoContext(this IServiceCollection services)
        {
            CamelCaseConventions();
            services.AddScoped<IMongoContext, MongoContext>();
            
            return services;
        }

        private static void CamelCaseConventions()
        {
            var pack = new ConventionPack
            {
                new CamelCaseElementNameConvention()
            };

            ConventionRegistry.Register("CamelCaseConventions", pack, t => t.FullName.StartsWith("Orangotango."));
        }
    }
}
