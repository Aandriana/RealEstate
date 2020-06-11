using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Interfaces;
using RealEstate.DAL.Entities;
using RealEstateIdentity.ViewModels;
using RealEstateIdentity.Mappers;

namespace RealEstateIdentity.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationService _authentication;
        private readonly IMapper _mapper;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IAuthenticationService authentication,
            IMapper mapper
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authentication = authentication;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<object> Login([FromBody] LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                return await _authentication.GenerateJwtToken(model.Email, appUser);
            }

            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }

        [HttpPost("register")]
        public async Task<object> Register([FromBody] RegisterViewModel model)
        {
            var user = _mapper.Map<User>(model);
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var currentUser =await  _userManager.FindByNameAsync(user.UserName);
                await _userManager.AddToRoleAsync(currentUser, model.RoleName);
                await _signInManager.SignInAsync(user, false);
                return await _authentication.GenerateJwtToken(model.Email, user);
            }

            throw new ApplicationException("UNKNOWN_ERROR");
        }
    }
}