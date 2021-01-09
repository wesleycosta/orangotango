using MongoDB.Driver;
using Orangotango.Core.Data;
using Orangotango.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orangotango.Business.Intefaces.Infrastructure
{
    public interface IMongoContext : IDisposable, IUnitOfWork
    {
        void AddCommand(Func<Task> func);
        void AddCommand(Func<Task> func, Entity entity);
        void AddCommand(Func<Task> func, List<Entity> entities);

        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
        IReadOnlyList<Entity> GetTracking();
    }
}
