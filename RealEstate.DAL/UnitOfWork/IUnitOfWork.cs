using RealEstate.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        IPropertyRepository PropertyRepository();
        IOfferRepository OfferRepository();
        Task<int> SaveChangesAsync();
    }
}
