using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.DAL.Entities;
using RealEstate.DAL.Repository.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RealEstate.DAL.Repository.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IdentityDbContext<User> _dbContext;

        public Repository(DbSet<TEntity> dbSet, IdentityDbContext<User> DbContext)
        {
            _dbSet = dbSet;
            _dbContext = DbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.FirstOrDefaultAsync(@where);
        }
        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<TEntity> GetIncludingAll(Expression<Func<TEntity, bool>> where)
        {
            var query = _dbSet.AsQueryable();
            query = _dbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations().Aggregate(query, (current, property) => current.Include(property.Name));
            return query.FirstOrDefault(where);
        }


        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = _dbSet.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }
    }
}
