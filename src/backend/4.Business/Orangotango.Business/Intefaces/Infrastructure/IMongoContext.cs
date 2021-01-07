using MongoDB.Driver;
using Orangotango.Core.Data;
using System;
using System.Threading.Tasks;

namespace Orangotango.Business.Intefaces.Infrastructure
{
    public interface IMongoContext : IDisposable, IUnitOfWork
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
