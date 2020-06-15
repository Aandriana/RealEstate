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
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PropertyCreateViewModel, PropertyCreateDto>()).CreateMapper();
                var propertyDto = mapper.Map<PropertyCreateViewModel, PropertyCreateDto>(property);
                await _propertyService.AddProperty(propertyDto);
                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(); 
            }
        }
    }
}