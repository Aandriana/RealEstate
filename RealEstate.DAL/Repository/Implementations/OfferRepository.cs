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
    public class OfferRepository: Repository<Offer>, IOfferRepository
    {
        public OfferRepository(DbSet<Offer> dbSet, IdentityDbContext<User> dbContext) : base(dbSet, dbContext)
        {
        }

        public async Task<List<Offer>> GetFilteredOffersForAgent(OfferListFilter filter, string agentId )
        {
            var offers = _dbSet.AsQueryable();

            if (filter.OfferStatus != null )
            {
                offers = offers.Where(p => p.Status == filter.OfferStatus);
            }

            if (agentId != null)
            {
                offers = offers.Where(o => o.AgentProfileId == agentId);
            }

            return await offers.Skip(filter.Skip).Take(filter.Take).ToListAsync();
        }

        public async Task<List<Offer>> GetFilteredOffersForUser(OfferListFilter filter, int propertyId)
        {
            var offers = _dbSet.AsQueryable();

            if (filter.OfferStatus != null)
            {
                offers = offers.Where(p => p.Status == filter.OfferStatus);
            }

            return await offers.Where(o => o.PropertyId == propertyId).Skip(filter.Skip).Take(filter.Take).ToListAsync();
        }
    }
}
