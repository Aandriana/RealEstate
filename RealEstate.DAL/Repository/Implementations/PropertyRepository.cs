using Common.FilterClasses;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.DAL.Entities;
using RealEstate.DAL.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.DAL.Repository.Implementations
{
    public class PropertyRepository : Repository<Property>, IPropertyRepository
    {
        public PropertyRepository(DbSet<Property> dbSet, IdentityDbContext<User> dbContext) : base(dbSet, dbContext)
        {
        }

        public async Task<List<Property>> GetFilteredProperties(PropertyListFilter filter)
        {
            var properties = _dbSet.AsQueryable();

            if (filter.Status != null && filter.Category != null)
            {
                properties = properties.Where(p => p.Status == filter.Status && p.Сategory == filter.Category);
            }

            if (filter.Status == null && filter.Category != null)
            {
                properties = properties.Where(p => p.Сategory == filter.Category);
            }

            if (filter.Status != null && filter.Category == null)
            {
                properties = properties.Where(p => p.Status == filter.Status);
            }

            return await properties.Skip(filter.Skip).Take(filter.Take).ToListAsync();
        }
    }
}