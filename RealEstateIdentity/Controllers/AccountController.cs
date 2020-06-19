using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Interfaces;
using RealEstate.DAL.Entities;
using RealEstateIdentity.ViewModels;

namespace RealEstateIdentity.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationService _authentication;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IAuthenticationService authentication,
            IMapper mapper,
            IFileService fileService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authentication = authentication;
            _mapper = mapper;
            _fileService = fileService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                    var token = await _authentication.GenerateJwtToken(appUser);
                    return Ok(new { Token = token });
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(model);

                if (model.Image != null)
                {
                    var imagePath = await _fileService.SaveFile(model.Image.OpenReadStream(),
                        Path.GetExtension(model.Image.FileName));
                    user.ImagePath = imagePath.ToString();
                }

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var currentUser = await _userManager.FindByNameAsync(user.UserName);
                    await _userManager.AddToRoleAsync(currentUser, "User");
                    await _signInManager.SignInAsync(user, false);
                    var token = await _authentication.GenerateJwtToken(user);
                    return Ok(new { Token = token });
                }
            }

            return BadRequest();
        }

        [HttpPost("agent")]
        public async Task<IActionResult> AgentRegister([FromForm] AgentRegisterViewModel agentRegister)
        {
            if(ModelState.IsValid)
            {
                var agent = _mapper.Map<User>(agentRegister);
                if (agentRegister.Image != null)
                {
                    var imagePath = await _fileService.SaveFile(agentRegister.Image.OpenReadStream(),
                        Path.GetExtension(agentRegister.Image.FileName));
                    agent.ImagePath = imagePath.ToString();
                    agent.AgentProfile.Id = agent.Id;
                    var result = await _userManager.CreateAsync(agent, agentRegister.Password);

                    if (result.Succeeded)
                    {
                        var currentUser = await _userManager.FindByNameAsync(agent.UserName);
                        await _userManager.AddToRoleAsync(currentUser, "Agent");
                        await _signInManager.SignInAsync(agent, false);
                        var token = await _authentication.GenerateJwtToken(agent);
                        return Ok(new { Token = token });
                    }
                }
            }

            return BadRequest();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> EditProfile([FromForm] UserDetailsViewModel editUser)
        {
            if (ModelState.IsValid)
            {
                var user = await _authentication.GetCurrentUserAsync();
                if (editUser.Image != null)
                {
                    var imagePath = await _fileService.SaveFile(editUser.Image.OpenReadStream(), Path.GetExtension(editUser.Image.FileName));
                    if (user.ImagePath != null) await _fileService.RemoveFile(user.ImagePath);
                    user.ImagePath = imagePath.ToString();
                }

                user.FirstName = editUser.FirstName;
                user.LastName = editUser.LastName;
                user.Email = editUser.Email;
                user.PhoneNumber = editUser.PhoneNumber;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    var currentUser = await _userManager.FindByNameAsync(user.UserName);
                    await _userManager.AddToRoleAsync(currentUser, "User");
                    await _signInManager.SignInAsync(user, false);
                    var token = await _authentication.GenerateJwtToken(user);
                    return Ok(new { Token = token });
                }
            }

            return BadRequest();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMyDetails()
        {
            var user = await _authentication.GetCurrentUserAsync();
            if (user == null) throw new UnauthorizedAccessException();
            var userDetails = _mapper.Map<UserDetailsViewModel>(user);
            return Ok(userDetails);
        }

    }
}