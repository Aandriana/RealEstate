using AutoMapper;
using Common.FilterClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.DTO;
using RealEstate.BLL.Interfaces;
using RealEstateIdentity.ViewModels;
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
        public async Task<IActionResult> SendOfferAsAnAgent([FromBody]OfferFromAgentViewModel offer)
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
        public async Task<IActionResult> AgentResponse(int id, [FromBody]AgentOfferResponseViewModel responseVm)
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
        public async Task<IActionResult> GetOffersForAgent(OfferListFilter filter)
        {
            var offers = await _offerService.GetAllOffersForAgent(filter);
            return Ok(offers);
        }

    }
}
