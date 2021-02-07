using MongoDB.Driver;
using Orangotango.Business.Intefaces.Infrastructure;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Core.Data;
using Orangotango.Core.DomainObjects;
using Orangotango.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orangotango.Data.Repository
{
    public abstract class Repository<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity, new()
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<TEntity> DbSet;
        public IUnitOfWork UnitOfWork => Context;
        protected FilterDefinitionBuilder<TEntity> Filter => Builders<TEntity>.Filter;

        protected Repository(IMongoContext context)
        {
            Context = context;
            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        #region INSERTS AND UPDATEDS

        public virtual void Add(TEntity entity)
        {
            entity.Created = DateTime.UtcNow;
            Context.AddCommand(() => DbSet.InsertOneAsync(entity), entity);
        }

        public virtual void AddRange(List<TEntity> entities)
        {
            Context.AddCommand(() => DbSet.InsertManyAsync(entities), entities as List<Entity>);
        }

        public virtual void Update(TEntity entity)
        {
            entity.LastUpdated = DateTime.UtcNow;
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("Id", entity.Id), entity), entity);
        }

        public virtual void UpdateRange(List<TEntity> entities)
        {
            entities.ForEach(p => Update(p));
        }

        public virtual void Remove(Guid id)
        {
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("Id", id)));
        }

        public virtual void RemoveRange(List<Guid> ids)
        {
            Context.AddCommand(() => DbSet.DeleteManyAsync(Builders<TEntity>.Filter.Eq("Id", ids)));
        }

        public async Task<bool> Commit()
        {
            return await Context.Commit();
        }

        #endregion

        #region QUERIES

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FirstOrDefaultAsync(Filter.Where(entity => entity.Id == id));
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            var all = await DbSet.FindAsync(Filter.Empty);
            return await all.ToListAsync();
        }

        #endregion

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
