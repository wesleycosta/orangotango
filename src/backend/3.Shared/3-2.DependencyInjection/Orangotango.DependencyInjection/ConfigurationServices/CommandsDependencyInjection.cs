using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Business.Application.Commands.Users;
using Orangotango.Core.Messages;

namespace Orangotango.DependencyInjection.ConfigurationServices
{
    internal static class CommandsDependencyInjection
    {
        internal static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<RegisterUserCommand, CommandHandlerResult>, RegisterUserCommandHandler>();
            services.AddScoped<IRequestHandler<SignInUserCommand, CommandHandlerResult>, SignInUserCommandHandler>();

            return services;
        }
    }
}
