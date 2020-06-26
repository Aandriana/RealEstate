using Common.FilterClasses;
using RealEstate.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.BLL.Interfaces
{
    public interface IOfferService
    {
        Task OfferFromUser (OfferFromUserDto offerDto);
        Task OfferFromAdmin (OfferFromAgentDto offerDto);
        Task UserResponse(int id, OfferResponseDto response);
        Task AgentResponse(int id, AgentOfferResponseDto response);
        Task<List<OfferDto>> GetAllOffersForAgent(OfferListFilter filter);
    }
}
