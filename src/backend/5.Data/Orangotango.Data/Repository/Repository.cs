using Microsoft.EntityFrameworkCore;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;
using Orangotango.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Orangotango.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly OrangotangoContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(OrangotangoContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await Task.CompletedTask;
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await Task.CompletedTask;
        }

        public virtual async Task Remove(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await Task.CompletedTask;
        }

        public async Task<bool> Commit()
        {
            return await Db.SaveChangesAsync() > 0;
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<List<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking()
                              .Where(predicate)
                              .ToListAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
