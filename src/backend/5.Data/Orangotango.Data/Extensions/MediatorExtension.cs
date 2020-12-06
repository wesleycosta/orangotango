using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Orangotango.Core.DomainObjects;
using Orangotango.Core.Mediator;

namespace Orangotango.Data.Extensions
{
    public static class MediatorExtension
    {
        public static async Task PublishEvents<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(p => p.Entity.EventNotification != null && p.Entity.EventNotification.Any());

            var domainEvents = domainEntities
                .SelectMany(p => p.Entity.EventNotification)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.PublishEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
