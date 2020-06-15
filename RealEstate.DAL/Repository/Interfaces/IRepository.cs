using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    { 
        Task AddAsync(TEntity entity);
    }
}
