using AutoMapper;
using Common.Enums;
using Common.FilterClasses;
using RealEstate.BLL.DTO;
using RealEstate.BLL.Interfaces;
using RealEstate.DAL.Entities;
using RealEstate.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.BLL.Services
{
    public class OfferServise: IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        
        public OfferServise(IUnitOfWork unitOfWork, IMapper mapper, IAuthenticationService authentication)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authenticationService = authentication;
        }

        public async Task OfferFromUser(OfferFromUserDto offerDto)
        {
            var offer = _mapper.Map<Offer>(offerDto);
            offer.Status = (int)OfferStatus.FromUser;
            var user = await _authenticationService.GetCurrentUserAsync();
            offer.CreatedById = user.Id;
            await _unitOfWork.Repository<Offer>().AddAsync(offer);

            var property = await _unitOfWork.Repository<Property>().GetAsync(p => p.Id == offerDto.PropertyId);
            if (property.UserId != user.Id) throw new FieldAccessException();
            await _unitOfWork.Repository<Offer>().AddAsync(offer);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task OfferFromAdmin (OfferFromAdminDto offerDto)
        {
            var offer = _mapper.Map<Offer>(offerDto);
            var agent = await _authenticationService.GetCurrentUserAsync();
            offer.AgentProfileId = agent.Id;
            offer.Status = (int)OfferStatus.FromAgent;
            offer.CreatedById = agent.Id;

            await _unitOfWork.Repository<Offer>().AddAsync(offer);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UserResponse(int id, OfferResponseDto response)
        {
            var offer = await _unitOfWork.Repository<Offer>().GetAsync(o => o.Id == id);
            var user = await _authenticationService.GetCurrentUserAsync();
            var property = await _unitOfWork.Repository<Property>().GetAsync(p => p.Id == offer.PropertyId);
            if (property.UserId != user.Id) throw new FieldAccessException();

            offer.Status = response.Response;
            offer.UpdatedById = user.Id;
            offer.UpdatedDateUtc = DateTime.Now;

            await _unitOfWork.Repository<Offer>().UpdateAsync(offer);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AgentResponse(int id, OfferResponseDto response)
        {
            var offer = await _unitOfWork.Repository<Offer>().GetAsync(o => o.Id == id);
            var agent = await _authenticationService.GetCurrentUserAsync();
            if (offer.AgentProfileId != agent.Id) throw new FieldAccessException();

            offer.Status = response.Response;
            offer.UpdatedById = agent.Id;
            offer.UpdatedDateUtc = DateTime.Now;

            await _unitOfWork.Repository<Offer>().UpdateAsync(offer);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<OfferDto>> GetAllOffersForAgent(OfferListFilter filter)
        {
            var agent = await _authenticationService.GetCurrentUserAsync();
            var offers = await _unitOfWork.OfferRepository().GetFilteredOffersForAgent(filter, agent.Id);
            var offerDtos = new List<OfferDto>();

            foreach (var offer in offers)
            {
                var offerDto = _mapper.Map<OfferDto>(offer);
                offerDtos.Add(offerDto);
            }
            return offerDtos;
        }
    }
}
