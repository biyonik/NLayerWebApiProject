using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayerWebApiProject.Core.Abstract;
using NLayerWebApiProject.Core.Repository;

namespace NLayerWebApiProject.Data.Repositories
{
    public class Repository<TEntity>: IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly AppDbContext Context;
        public readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context)
        {
            Context = context;
            _dbSet = Context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> entities =  _dbSet.Where(predicate);
            return entities;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = await _dbSet.AddAsync(entity);
            return addedEntity.Entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}