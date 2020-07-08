using AutoMapper;
using Common.FilterClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.DTO;
using RealEstate.BLL.Interfaces;
using RealEstateIdentity.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateIdentity.Controllers
{
    [Route("api/property")]
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;
        private readonly IMapper _mapper;
        private readonly IQuestionService _questionService;

        public PropertyController(IPropertyService propertyService, IMapper mapper, IQuestionService questionService)
        {
            _propertyService = propertyService;
            _mapper = mapper;
            _questionService = questionService;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddProperty([FromForm] PropertyCreateViewModel property)
        {
            if (property == null)
            {
                throw new ArgumentException($"{nameof(property)} can not be null");
            }
            if (ModelState.IsValid)
            {
                var propertyDto = _mapper.Map<PropertyCreateDto>(property);
                await _propertyService.AddProperty(propertyDto);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPatch("{id}/delete")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            await _propertyService.DeleteProperty(id);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateProperty(int id, [FromForm]PropertyUpdateViewModel property)
        {
            if (property == null)
            {
                throw new ArgumentException($"{nameof(property)} can not be null");
            }

            if (ModelState.IsValid)
            {
                var propertyDto = _mapper.Map<PropertyUpdateDto>(property);
                foreach (var question in property.Questions)
                {
                    var questionDto = _mapper.Map<QuestionsDto>(question);
                    propertyDto.QuestionsDtos.Add(questionDto);
                }
                await _propertyService.UpdateProperty(id, propertyDto);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPatch("{id}/restore")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> RestoreProperty(int id)
        {
            await _propertyService.RestoreProperty(id);
            return Ok();
        }

        [HttpPut("{id}/photos")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdatePropertyPhotos(int id, PropertyUpdatePhotosViewModel updatePhotos)
        {
            var updatePhotosDto = _mapper.Map<PropertyUpdatePhotosDto>(updatePhotos);
            await _propertyService.UpdatePhotos(id, updatePhotosDto);
            return Ok();
        }

        // GET: api/property/user?pageNumber=2&pageSize=10&Category=1&Status=2
        [HttpGet("user")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetPropertiesForUser([FromQuery]PropertyListFilter filter)
        {
            var propertiesDto = await _propertyService.GetPropertiesForUser(filter);
            var propertiesVM = new List<PropertyListViewModel>();
            foreach (var propertyDto in propertiesDto)
            {
                var propertyVm = _mapper.Map<PropertyListViewModel>(propertyDto);
                propertiesVM.Add(propertyVm);
            }
            return Ok(propertiesVM);
        }

        // GET: api/property/agent?pageNumber=2&pageSize=10&
        [HttpGet("agent")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetProperties([FromQuery]PaginationParameters paginationParameters)
        {
            var propertiesDto = await _propertyService.GetPropertiesForAgent(paginationParameters);
            var propertiesVM = new List<PropertyListViewModel>();
            foreach (var propertyDto in propertiesDto)
            {
                var propertyVm = _mapper.Map<PropertyListViewModel>(propertyDto);
                propertiesVM.Add(propertyVm);
            }
            return Ok(propertiesVM);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetPropertyById(int id)
        {
            var property = await _propertyService.GetPropertyById(id);
            return Ok(property);
        }

        [HttpGet("{id}/offers")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetOffersForProperty(int id, [FromQuery]OfferListFilter listFilter)
        {
            var offers = await _propertyService.GetPropertyOffers(id, listFilter);
            return Ok(offers);
        }

        [HttpPost("{id}/questions")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddQuestions(int id, [FromBody] AddQuestionViewModel questionsVm)
        {
            if (ModelState.IsValid)
            {
                var questionsDto = _mapper.Map<AddQuestionDto>(questionsVm);
                await _propertyService.AddNewQuestions(id, questionsDto);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("question/{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> RemoveQuestion(int id)
        {
            await _questionService.DeleteQuestion(id);
            return Ok();
        }

        [HttpPut("question/{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] QuestionUpdateViewModel updateViewModel)
        {
            var updateDto = _mapper.Map<QuestionUpdateDto>(updateViewModel);
            await _questionService.UpdateQuestion(id, updateDto);
            return Ok();
        }

    }
}