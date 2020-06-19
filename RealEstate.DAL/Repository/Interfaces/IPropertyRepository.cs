using Common.FilterClasses;
using RealEstate.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.DAL.Repository.Interfaces
{
    public interface  IPropertyRepository : IRepository<Property>
    {
        Task<List<Property>> GetFilteredProperties(PropertyListFilter filter);
    }
}
