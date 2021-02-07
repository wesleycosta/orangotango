using MongoDB.Driver;
using System.Threading.Tasks;

namespace Orangotango.Data.Extensions
{
    public static class MongoExtensions
    {
        public static async Task<TDocument> FirstOrDefaultAsync<TDocument>(this IMongoCollection<TDocument> collection, FilterDefinition<TDocument> filter)
        {
            var cursor = await collection.FindAsync(filter);
            return await cursor.FirstOrDefaultAsync();
        }

        public static async Task<bool> AnyAsync<TDocument>(this IMongoCollection<TDocument> collection, FilterDefinition<TDocument> filter)
        {
            var cursor = await FirstOrDefaultAsync(collection, filter);
            return cursor != null;
        }
    }
}
