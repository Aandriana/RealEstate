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
    [Route("api/offer")]
    public class OfferController : Controller
    {
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> SendOfferAsAnUser()
        {

        }

        [HttpPost]
        [Authorize (Roles = "Agent")]
        public async Task<IActionResult> SendOfferAsAnAgent()
        {

        }
    }
}
