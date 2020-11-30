using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

namespace Orangotango.Data.Context
{
    public static class DbContextConfig
    {
        public static IServiceCollection AddOrangotangoContext(this IServiceCollection services, string connection)
        {
            services.AddDbContext<OrangotangoContext>(options =>
            {
                options.UseNpgsql(connection);
            });

            return services;
        }

        public static void UpdateDatabase(this IServiceProvider service)
        {
            using var context = service.GetService<OrangotangoContext>();
            context.Database.Migrate();
        }
    }
}
