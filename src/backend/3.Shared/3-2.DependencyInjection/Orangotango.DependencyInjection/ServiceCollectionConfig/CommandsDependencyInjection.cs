using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Business.Application.Commands.Emails;
using Orangotango.Business.Application.Commands.RoomTypes;
using Orangotango.Business.Application.Commands.Users;
using Orangotango.Core.Messages;

namespace Orangotango.DependencyInjection.ServiceCollectionConfig
{
    internal static class CommandsDependencyInjection
    {
        internal static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<RegisterUserCommand, CommandHandlerResult>, RegisterUserCommandHandler>();
            services.AddScoped<IRequestHandler<SignInUserCommand, CommandHandlerResult>, SignInUserCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterRoomTypeCommand, CommandHandlerResult>, RegisterRoomTypeCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateRoomTypeCommand, CommandHandlerResult>, UpdateRoomTypeCommandHandler>();
            services.AddScoped<IRequestHandler<SendEmailCommand, CommandHandlerResult>, SendEmailCommandHandler>();

            return services;
        }
    }
}
