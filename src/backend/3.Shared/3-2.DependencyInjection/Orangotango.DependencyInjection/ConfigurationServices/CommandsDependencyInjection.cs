using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Business.Application.Commands.Users;

namespace Orangotango.DependencyInjection.ConfigurationServices
{
    internal static class CommandsDependencyInjection
    {
        internal static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<RegisterUserCommand, ValidationResult>, RegisterUserCommandHandler>();
            services.AddScoped<IRequestHandler<MakeLoginUserCommand, ValidationResult>, MakeLoginUserCommandHandler>();

            return services;
        }
    }
}
