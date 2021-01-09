using System.Linq;
using System.Threading.Tasks;
using Orangotango.Business.Intefaces.Infrastructure;
using Orangotango.Core.Mediator;

namespace Orangotango.Data.Extensions
{
    public static class MediatorExtension
    {
        public static async Task PublishContext<T>(this IMediatorHandler mediator, T ctx) where T : IMongoContext
        {
            var domainEntities = ctx.GetTracking()
                                    .Where(p => p.ExistEvents());

            var domainEvents = domainEntities
                .SelectMany(p => p.GetEvents())
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.ClearEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.PublishEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
