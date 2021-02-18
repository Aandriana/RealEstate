using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RealEstate.DAL.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);
        Task<TEntity> GetIncludingAll(Expression<Func<TEntity, bool>> where);
        void Remove(TEntity entity);
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);
    }
}
