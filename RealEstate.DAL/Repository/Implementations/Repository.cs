using Microsoft.EntityFrameworkCore;
using RealEstate.DAL.Repository.Interfaces;
using System.Threading.Tasks;

namespace RealEstate.DAL.Repository.Implementations
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity: class
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }
    }
}
