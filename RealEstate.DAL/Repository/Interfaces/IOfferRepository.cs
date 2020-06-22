using Common.FilterClasses;
using RealEstate.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.DAL.Repository.Interfaces
{
    public interface IOfferRepository: IRepository<Offer>
    {
        Task<List<Offer>> GetFilteredOffersForAgent(OfferListFilter filter, string agentId);
        Task<List<Offer>> GetFilteredOffersForUser(OfferListFilter filter, int propertyId);
    }
}
