using RealEstate.DAL.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace RealEstate.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
