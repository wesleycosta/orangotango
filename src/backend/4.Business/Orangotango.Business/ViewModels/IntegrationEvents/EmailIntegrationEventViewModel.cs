using Orangotango.Core.Messages.Integration;
using System;

namespace Orangotango.Business.ViewModels.IntegrationEvents
{
    public class EmailIntegrationEventViewModel : IntegrationEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
