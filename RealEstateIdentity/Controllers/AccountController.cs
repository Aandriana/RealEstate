using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.FilterClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.DTO;
using RealEstate.BLL.DTO.UserDtos;
using RealEstate.BLL.Interfaces;
using RealEstateIdentity.ViewModels;
using RealEstateIdentity.ViewModels.UserViewModels;

namespace RealEstateIdentity.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authentication;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IUserService _userService;

        public AccountController(
            IAuthenticationService authentication,
            IMapper mapper,
            IFileService fileService,
            IUserService userService
            )
        {
            _authentication = authentication;
            _mapper = mapper;
            _fileService = fileService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginDto = _mapper.Map<LoginDto>(model);
                var token = _userService.Login(loginDto);
                if (token != null) return Ok(new { Token = token });
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<RegisterDto>(model);

                if (model.Image != null)
                {
                    var imagePath = await _fileService.SaveFile(model.Image.OpenReadStream(),
                        Path.GetExtension(model.Image.FileName));
                    user.ImagePath = imagePath.ToString();
                }
                var token = _userService.Register(user);
                if (token != null) return Ok(new { Token = token });
            }

            return BadRequest();
        }

        [HttpPost("agent")]
        public async Task<IActionResult> AgentRegister([FromForm] AgentRegisterViewModel agentRegister)
        {
            if (ModelState.IsValid)
            {
                var agent = _mapper.Map<AgentRegisterDto>(agentRegister);
                if (agentRegister.Image != null)
                {
                    var imagePath = await _fileService.SaveFile(agentRegister.Image.OpenReadStream(),
                        Path.GetExtension(agentRegister.Image.FileName));
                    agent.ImagePath = imagePath.ToString();
                }

                var token = await _userService.AgentRegister(agent);
                if (token != null) return Ok(new { Token = token });
            }

            return BadRequest();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> EditProfile([FromForm] UserDetailsViewModel editUser)
        {
            if (ModelState.IsValid)
            {
                var userDto = _mapper.Map<UserDetailsDto>(editUser);
                var token = await _userService.EditUser(userDto);
                if (token != null) return Ok(new { Token = token });
            }

            return BadRequest();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMyDetails()
        {
            var detailsdDto = await _userService.GetMyInfo();
            var detailsVm = _mapper.Map<UserDetailsViewModel>(detailsdDto);
            return Ok(detailsVm);
        }

        [HttpGet("agents")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllAgents(PaginationParameters pagination)
        {
            var agentDtos = await _userService.GetAllAgents(pagination);
            return Ok(agentDtos);
        }

        [HttpPut("agent")]
        [Authorize(Roles = "Agent")]
        public async Task<IActionResult> EditAgentProfile([FromForm]EditUserProfileViewModel editUser)
        {
            if (ModelState.IsValid)
            {
                var editDto = _mapper.Map<EditUserProfileDto>(editUser);
                var token = await _userService.EditAgentProfile(editDto);
                if (token != null) return Ok(new { Token = token });
            }

            return BadRequest();
        }

        [HttpGet("agent/{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAgentById(string id)
        {
            var agentDto = await _userService.GetAgentById(id);
            var agentVm = _mapper.Map<GetAgentByIdInfoViewModel>(agentDto);
            return Ok(agentVm);
        }

        [HttpPost("feedback")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddFeedback([FromBody]FeedBackViewModel feedBack)
        {
            if (ModelState.IsValid)
            {
                var feedbackDto = _mapper.Map<FeedBackDto>(feedBack);
                await _userService.AddFeedBackForAgent(feedbackDto);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("agent")]
        [Authorize(Roles = "Agent")]
        public async Task<IActionResult> GetMyAgentProfile()
        {
            var agentDto = await _userService.GetCurrentAgent();
            var agentVm = _mapper.Map<GetAgentByIdInfoViewModel>(agentDto);
            return Ok(agentVm);
        }

        [HttpGet("my/feedbacks")]
        [Authorize(Roles = "Agent")]
        public async Task<IActionResult> GetMyFeedbacks()
        {
            var feetbacks = await _userService.GetCurrentAgentFeedbacks();
            return Ok(feetbacks);
        }
    }
}