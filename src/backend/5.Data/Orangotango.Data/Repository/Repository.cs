using MongoDB.Driver;
using Orangotango.Business.Intefaces.Infrastructure;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Core.Data;
using Orangotango.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orangotango.Data.Repository
{
    public abstract class Repository<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity, new()
    {
        protected readonly IMongoContext _context;
        protected IMongoCollection<TEntity> _dbSet;
        public IUnitOfWork UnitOfWork => _context;

        protected Repository(IMongoContext context)
        {
            _context = context;
            _dbSet = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        #region INSERTS AND UPDATEDS

        public virtual void Add(TEntity entity)
        {
            entity.Created = DateTime.UtcNow;
            _context.AddCommand(() => _dbSet.InsertOneAsync(entity));
        }

        public virtual void AddRange(List<TEntity> entities)
        {
            _context.AddCommand(() => _dbSet.InsertManyAsync(entities));
        }

        public virtual void Update(TEntity entity)
        {
            entity.LastUpdated = DateTime.UtcNow;
            _context.AddCommand(() => _dbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("Id", entity.Id), entity));
        }

        public virtual void UpdateRange(List<TEntity> entities)
        {
            entities.ForEach(p => Update(p));
        }

        public virtual void Remove(Guid id)
        {
            _context.AddCommand(() => _dbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("Id", id)));
        }

        public virtual void RemoveRange(List<Guid> ids)
        {
            _context.AddCommand(() => _dbSet.DeleteManyAsync(Builders<TEntity>.Filter.Eq("Id", ids)));
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChanges() > 0;
        }

        #endregion

        #region QUERIES

        public virtual async Task<TEntity> GetById(Guid id)
        {
            var data = await _dbSet.FindAsync(Builders<TEntity>.Filter.Eq("Id", id));
            return await data.FirstOrDefaultAsync();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            var all = await _dbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return await all.ToListAsync();
        }

        #endregion

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
