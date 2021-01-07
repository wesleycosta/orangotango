using Orangotango.Core.Data;
using Orangotango.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orangotango.Business.Intefaces.Repositories
{
    public interface IRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
    {
        void Add(TEntity entity);
        void AddRange(List<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        void Remove(Guid id);
        void RemoveRange(List<Guid> ids);
        Task<bool> Commit();
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
    }
}
