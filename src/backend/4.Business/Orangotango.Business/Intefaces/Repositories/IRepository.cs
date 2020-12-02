using Orangotango.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Orangotango.Business.Intefaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task AddRange(List<TEntity> entities);
        Task Update(TEntity entity);
        Task UpdateRange(List<TEntity> entities);
        Task Remove(Guid id);
        Task RemoveRange(List<Guid> ids);
        Task<bool> Commit();
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
    }
}
