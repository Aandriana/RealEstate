using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.DTO;
using RealEstate.BLL.Interfaces;
using RealEstateIdentity.ViewModels;
using System;
using System.Threading.Tasks;

namespace RealEstateIdentity.Controllers
{
    [Route("api/property")]
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost("create")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddProperty([FromForm] PropertyCreateViewModel property)
        {
            if (property == null)
            {
                throw new ArgumentException($"{nameof(property)} can not be null");
            }
            if (ModelState.IsValid)
            {

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PropertyCreateViewModel, PropertyCreateDto>()).CreateMapper();
                var propertyDto = mapper.Map<PropertyCreateViewModel, PropertyCreateDto>(property);
                await _propertyService.AddProperty(propertyDto);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("{id}/delete")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            await _propertyService.DeleteProperty(id);
            return Ok();
        }

        [HttpPost("{id}/update")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateProperty(int id, [FromForm]PropertyUpdateViewModel property)
        {
            if (property == null)
            {
                throw new ArgumentException($"{nameof(property)} can not be null");
            }

            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PropertyUpdateViewModel, PropertyUpdateDto>()).CreateMapper();
                var propertyDto = mapper.Map<PropertyUpdateDto>(property);

                await _propertyService.UpdateProperty(id, propertyDto);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("{id}/restore")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> RestoreProperty(int id)
        {
            await _propertyService.RestoreProperty(id);
            return Ok();
        }
    }
}