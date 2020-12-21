using Microsoft.EntityFrameworkCore;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;
using Orangotango.Core.Data;
using Orangotango.Core.DomainObjects;
using Orangotango.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Orangotango.Data.Repository
{
    public abstract class Repository<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity, new()
    {
        protected readonly OrangotangoContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        protected Repository(OrangotangoContext db)
        {
            this._db = db;
            _dbSet = db.Set<TEntity>();
        }

        public IUnitOfWork UnitOfWork => _db;

        public virtual async Task Add(TEntity entity)
        {
            _dbSet.Add(entity);
            await Task.CompletedTask;
        }

        public virtual async Task AddRange(List<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            await Task.CompletedTask;
        }

        public virtual async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }

        public virtual async Task UpdateRange(List<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            await Task.CompletedTask;
        }

        public virtual async Task Remove(Guid id)
        {
            _dbSet.Remove(new TEntity { Id = id });
            await Task.CompletedTask;
        }

        public virtual async Task RemoveRange(List<Guid> ids)
        {
            _dbSet.RemoveRange(ids.Select(id => new TEntity { Id = id }));
            await Task.CompletedTask;
        }

        public async Task<bool> Commit()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        #region QUERIES

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking()
                              .Where(predicate)
                              .ToListAsync();
        }

        #endregion

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
