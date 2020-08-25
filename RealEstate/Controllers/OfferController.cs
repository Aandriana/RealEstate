using AutoMapper;
using Common.FilterClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.DTO;
using RealEstate.BLL.Interfaces;
using RealEstateIdentity.ViewModels;
using RealEstateIdentity.ViewModels.OfferViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateIdentity.Controllers
{
    [Route("api/offer")]
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;

        public OfferController(IOfferService offerService, IMapper mapper)
        {
            _mapper = mapper;
            _offerService = offerService;
        }


        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> SendOfferAsAnUser([FromBody] OfferFromUserViewModel offerVm)
        {
            if (ModelState.IsValid)
            {
                var offer = _mapper.Map<OfferFromUserDto>(offerVm);
                await _offerService.OfferFromUser(offer);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("agent")]
        [Authorize(Roles = "Agent")]
        public async Task<IActionResult> SendOfferAsAnAgent([FromForm] OfferFromAgentViewModel offer)
        {
            if (ModelState.IsValid)
            {
                var offerDto = _mapper.Map<OfferFromAgentDto>(offer);
                await _offerService.OfferFromAdmin(offerDto);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UserResponse(int id, [FromBody] OfferResponseViewModel responseVm)
        {
            if (ModelState.IsValid)
            {
                var responseDto = _mapper.Map<OfferResponseDto>(responseVm);
                await _offerService.UserResponse(id, responseDto);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("agent/{id}")]
        [Authorize(Roles = "Agent")]
        public async Task<IActionResult> AgentResponse(int id, [FromForm]AgentOfferResponseViewModel responseVm)
        {
            if (ModelState.IsValid)
            {
                var responceDto = _mapper.Map<AgentOfferResponseDto>(responseVm);
                await _offerService.AgentResponse(id, responceDto);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        [Authorize(Roles = "Agent")]
        public async Task<IActionResult> GetOffersForAgent([FromQuery]OfferListFilter filter)
        {
            var offers = await _offerService.GetAllOffersForAgent(filter);
            var offersVm = new List<OfferViewModel>();
            foreach (var offer in offers)
            {
                var offerVm = _mapper.Map<OfferViewModel>(offer);
                offersVm.Add(offerVm);
            }
            return Ok(offersVm);
        }

        [HttpGet("{id}/property")]
        [Authorize]
        public async Task<IActionResult> GetPropertyId(int id)
        {
            var propertyId = await _offerService.GetPropertyId(id);
            return Ok(propertyId);
        }

    }
}
