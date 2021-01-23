using Orangotango.Business.Intefaces.Services;
using Orangotango.Business.Models.Types;
using Orangotango.Business.ViewModels.IntegrationEvents;
using Orangotango.MessageBus;
using System.Text.Json;

namespace Orangotango.Business.Services
{
    public class EmailIntegrationHandler : IEmailIntegrationHandler
    {
        private readonly IMessageBus _messageBus;
        private readonly IQueueFactory _queueFactory;
        private readonly IEmailService _emailService;

        public EmailIntegrationHandler(IMessageBus messageBus,
                                       IQueueFactory queueFactory,
                                       IEmailService emailService)
        {
            _messageBus = messageBus;
            _queueFactory = queueFactory;
            _emailService = emailService;

            InitializeMessageBus();
        }

        private void InitializeMessageBus()
        {
            var busSettings = _queueFactory.GetBusSettings();
            var queueSettings = _queueFactory.GetQueueSettings(QueueType.EmailQueue);

            _messageBus.Initialize(busSettings, queueSettings);
        }

        public void Execute()
        {
            _messageBus.Subscribe(async (string json) =>
           {
               var integration = JsonSerializer.Deserialize<EmailIntegrationEventViewModel>(json);
               await _emailService.Send(integration.Email, "Primeiro acesso", $"Olá <b>{integration.Name}</b>");
           });
        }
    }
}
