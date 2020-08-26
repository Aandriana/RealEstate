using AutoMapper;
using Common.Enums;
using Common.FilterClasses;
using Microsoft.EntityFrameworkCore;
using RealEstate.BLL.DTO;
using RealEstate.BLL.Interfaces;
using RealEstate.DAL.Entities;
using RealEstate.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.BLL.Services
{
    public class OfferServise : IOfferService
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
            foreach(var ppropertyId in offerDto.PropertyId)
            {
                var offer = new Offer();
                offer.Status = (int)OfferStatus.FromUser;
                var user = await _authenticationService.GetCurrentUserAsync();
                offer.CreatedById = user.Id;
                offer.PropertyId = ppropertyId;
                offer.AgentProfileId = offerDto.AgentProfileId;
                var agent = await _unitOfWork.Repository<AgentProfile>().GetAsync(a => a.Id == offerDto.AgentProfileId);
                offer.Rate = agent.DefaultRate;

                var property = await _unitOfWork.Repository<Property>().GetAsync(p => p.Id == ppropertyId);
                if (property.UserId != user.Id) throw new FieldAccessException();
                await _unitOfWork.Repository<Offer>().AddAsync(offer);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task OfferFromAdmin(OfferFromAgentDto offerDto)
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
            var agent = await _unitOfWork.Repository<AgentProfile>().GetAsync(a => a.Id == offer.AgentProfileId);
            if (property.UserId != user.Id) throw new FieldAccessException();

            offer.Status = response.Response;
            offer.UpdatedById = user.Id;
            offer.UpdatedDateUtc = DateTime.Now;

            if (offer.Status == (int)OfferStatus.Confirmed)
            {
                property.Status = (int)PropertyStatus.FoundAgent;
                await _unitOfWork.Repository<Property>().UpdateAsync(property);
            }

            if (offer.Status == (int)OfferStatus.Failed)
            {
                property.Status = (int)PropertyStatus.LookingForAgent;
                await _unitOfWork.Repository<Property>().UpdateAsync(property);
                agent.FailedSales++;
            }

            if (offer.Status == (int)OfferStatus.Sold)
            {
                property.Status = (int)PropertyStatus.Sold;
                await _unitOfWork.Repository<Property>().UpdateAsync(property);
                agent.SuccessSales++;
            }

            await _unitOfWork.Repository<Offer>().UpdateAsync(offer);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<int> GetPropertyId(int id)
        {
            var offer = await _unitOfWork.Repository<Offer>().GetAsync(o => o.Id == id);
            return offer.PropertyId;
        }
        public async Task<string> GetAgentId(int id)
        {
            var offer = await _unitOfWork.Repository<Offer>().GetAsync(o => o.Id == id);
            return offer.AgentProfileId;
        }

        public async Task AgentResponse(int id, AgentOfferResponseDto response)
        {
            var offer = await _unitOfWork.Repository<Offer>().GetAsync(o => o.Id == id);
            var agent = await _authenticationService.GetCurrentUserAsync();
            if (offer.AgentProfileId != agent.Id) throw new FieldAccessException();

            offer.Status = response.Response;
            offer.UpdatedById = agent.Id;
            offer.UpdatedDateUtc = DateTime.Now;
            offer.Comment = response.Comment;
            offer.Rate = response.Rate;
            await _unitOfWork.Repository<Offer>().UpdateAsync(offer);

            foreach (var answerDto in response.Answers)
            {
                var answer = _mapper.Map<Answer>(answerDto);
                answer.CreatedById = agent.Id;
                answer.OfferId = id;
                await _unitOfWork.Repository<Answer>().AddAsync(answer);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<OfferDto>> GetAllOffersForAgent(OfferListFilter filter)
        {
            var agent = await _authenticationService.GetCurrentUserAsync();
            var offers = await GetFilteredOffersForAgent(filter, agent.Id);
            var offerDtos = new List<OfferDto>();

            foreach (var offer in offers)
            {
                var offerDto = _mapper.Map<OfferDto>(offer);
                var answers = await _unitOfWork.Repository<Answer>().GetAllAsync(a => a.OfferId == offer.Id);
                if (answers != null)
                {
                    foreach (var answer in answers)
                    {
                        var answerDto = _mapper.Map<AnswerDto>(answer);
                        offerDto.Answers.Add(answerDto);

                    }
                }
                offerDtos.Add(offerDto);
            }
            return offerDtos;
        }

        private async Task<List<Offer>> GetFilteredOffersForAgent(OfferListFilter filter, string agentId)
        {
            var offers = await _unitOfWork.Repository<Offer>().GetAllAsync();

            if (filter.OfferStatus != null && agentId != null)
            {
                offers = await _unitOfWork.Repository<Offer>().GetAllAsync(p => p.Status == filter.OfferStatus && p.AgentProfileId == agentId);
            }

            else if (agentId != null)
            {
                offers = await _unitOfWork.Repository<Offer>().GetAllAsync(o => o.AgentProfileId == agentId);
            }

            return await offers.Skip(filter.Skip).Take(filter.Take).ToListAsync();
        }

    }
}
