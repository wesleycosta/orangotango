using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Orangotango.Core.Mediator
{
    public static class MediatorConfig
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(MediatorConfig));
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            return services;
        }
    }
}
