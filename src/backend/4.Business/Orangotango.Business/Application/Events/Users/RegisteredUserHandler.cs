using MediatR;
using Orangotango.Business.Intefaces.Services;
using Orangotango.Business.Models.Types;
using Orangotango.Business.ViewModels.IntegrationEvents;
using Orangotango.MessageBus;
using System.Threading;
using System.Threading.Tasks;

namespace Orangotango.Business.Application.Events.Users
{
    public class RegisteredUserHandler : INotificationHandler<RegisteredUserEvent>
    {
        private readonly IMessageBus _messageBus;
        private readonly IQueueFactory _queueFactory;

        public RegisteredUserHandler(IMessageBus messageBus,
                                     IQueueFactory queueFactoryService)
        {
            _messageBus = messageBus;
            _queueFactory = queueFactoryService;

            InitializeMessageBus();
        }

        private void InitializeMessageBus()
        {
            var busSettings = _queueFactory.GetBusSettings();
            var queueSettings = _queueFactory.GetQueueSettings(QueueType.EmailQueue);

            _messageBus.Initialize(busSettings, queueSettings);
        }

        public async Task Handle(RegisteredUserEvent notification, CancellationToken cancellationToken)
        {
            var notificationViewModel = new EmailIntegrationEventViewModel
            {
                Id = notification.AggregateId,
                Name = notification.Name,
                Email = notification.Email.Address
            };

            _messageBus.Publish(notificationViewModel);
            await Task.CompletedTask;
        }
    }
}
