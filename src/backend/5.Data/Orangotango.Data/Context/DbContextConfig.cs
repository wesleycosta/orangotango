using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

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

        public static void UpdateDatabase(this IServiceScope serviceScope)
        {
            using var context = serviceScope.ServiceProvider.GetService<OrangotangoContext>();
            context.Database.Migrate();
        }
    }
}
