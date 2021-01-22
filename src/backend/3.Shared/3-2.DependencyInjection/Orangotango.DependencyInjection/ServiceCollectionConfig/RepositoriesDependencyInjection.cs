using Microsoft.Extensions.DependencyInjection;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Data.Repository;

namespace Orangotango.DependencyInjection.ServiceCollectionConfig
{
    internal static class RepositoriesDependencyInjection
    {
        internal static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IHouseGuestRepository, HouseGuestRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();

            return services;
        }
    }
}
