using AutoMapper;
using Common.FilterClasses;
using Microsoft.AspNetCore.Identity;
using RealEstate.BLL.DTO;
using RealEstate.BLL.DTO.UserDtos;
using RealEstate.BLL.Interfaces;
using RealEstate.DAL.Entities;
using RealEstate.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationService _authentication;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IAuthenticationService authentication, IMapper mapper, IFileService fileService, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authentication = authentication;
            _mapper = mapper;
            _fileService = fileService;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Login(LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                var token = await _authentication.GenerateJwtToken(appUser);
                return token;
            }
            return null;
        }

        public async Task<string> Register(RegisterDto model)
        {
            var user = _mapper.Map<User>(model);
            user.ImagePath = model.ImagePath;
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var currentUser = await _userManager.FindByNameAsync(user.UserName);
                await _userManager.AddToRoleAsync(currentUser, "User");
                await _signInManager.SignInAsync(user, false);
                var token = await _authentication.GenerateJwtToken(user);
                return token;
            }

            return null;
        }

        public async Task<string> AgentRegister(AgentRegisterDto agentRegister)
        {
            var agent = _mapper.Map<User>(agentRegister);
            agent.ImagePath = agentRegister.ImagePath;
            agent.AgentProfile.Id = agent.Id;
            var result = await _userManager.CreateAsync(agent, agentRegister.Password);

             if (result.Succeeded)
            {
                var currentUser = await _userManager.FindByNameAsync(agent.UserName);
                await _userManager.AddToRoleAsync(currentUser, "Agent");
                await _signInManager.SignInAsync(agent, false);
                var token = await _authentication.GenerateJwtToken(agent);
                return token;
            }

            return null;
        }

        public async Task<string> EditUser(UserDetailsDto editUser)
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
                return token;
            }

            return null;
        }

        public async Task<UserDetailsDto> GetMyInfo()
        {
            var user = await _authentication.GetCurrentUserAsync();
            if (user == null) throw new UnauthorizedAccessException();
            var userDetails = _mapper.Map<UserDetailsDto>(user);
            return userDetails;
        }

        public async Task<List<UsersListDto>> GetAllAgents(PaginationParameters pagination)
        {
            var users = await _userManager.GetUsersInRoleAsync("Agent");
            var usersDto = new List<UsersListDto>();
            foreach (var user in users)
            {
                var userDto = _mapper.Map<UsersListDto>(user);
                var agent = await _unitOfWork.Repository<AgentProfile>().GetAsync(a => a.Id == user.Id);
                userDto.AgentProfile = _mapper.Map<AgentsListDto>(agent);
                usersDto.Add(userDto);
            }

            return usersDto.Skip(pagination.Skip).Take(pagination.Take).ToList();
        }

        public async Task<string> EditAgentProfile(EditUserProfileDto editUser)
        {
            var user = await _authentication.GetCurrentUserAsync();
            if (editUser.Image != null)
            {
                var imagePath = await _fileService.SaveFile(editUser.Image.OpenReadStream(), Path.GetExtension(editUser.Image.FileName));
                if (user.ImagePath != null) await _fileService.RemoveFile(user.ImagePath);
                user.ImagePath = imagePath.ToString();
                user.FirstName = editUser.FirstName;
                user.LastName = editUser.LastName;
                user.Email = editUser.Email;
                user.PhoneNumber = editUser.PhoneNumber;
            }

            await _userManager.UpdateAsync(user);

            var agent = await _unitOfWork.Repository<AgentProfile>().GetAsync(a => a.Id == user.Id);
            agent.BirthDate = editUser.AgentProfile.BirthDate;
            agent.City = editUser.AgentProfile.City;
            agent.DefaultRate = editUser.AgentProfile.DefaultRate;
            agent.Description = editUser.AgentProfile.Description;

            await _unitOfWork.Repository<AgentProfile>().UpdateAsync(agent);
            await _unitOfWork.SaveChangesAsync();

            var currentUser = await _userManager.FindByNameAsync(user.UserName);
            await _userManager.AddToRoleAsync(currentUser, "User");
            await _signInManager.SignInAsync(user, false);
            var token = await _authentication.GenerateJwtToken(user);
            return token;
        }

        public async Task<GetAgentByIdInfoDto> GetAgentById(string agentId)
        {
            var agent = await _unitOfWork.Repository<AgentProfile>().GetAsync(a => a.Id == agentId);
            var userAgent = await _userManager.FindByIdAsync(agentId);
            var agentDto = _mapper.Map<GetAgentByIdInfoDto>(agent);

            var feedbacks = await _unitOfWork.Repository<Feedback>().GetAllAsync(o => o.AgentId == agentId);
            var feedbacksDto = agentDto.FeedBacks;
            foreach (var feedback in feedbacks)
            {
                var feedbackDto = _mapper.Map<FeedbackListDto>(feedback);
                var user = await _userManager.FindByIdAsync(feedback.UserId);
                feedbackDto.FirstName = user.FirstName;
                feedbackDto.LastName = user.LastName;
                feedbackDto.ImagePath = user.ImagePath;
                feedbacksDto.Add(feedbackDto);
            }


            agentDto.ImagePath = userAgent.ImagePath;
            agentDto.FirstName = userAgent.FirstName;
            agentDto.LastName = userAgent.LastName;
            return agentDto;
        }

        public async Task AddFeedBackForAgent(FeedBackDto feedBackDto)
        {
            var user = await _authentication.GetCurrentUserAsync();
            var feedback = _mapper.Map<Feedback>(feedBackDto);
            feedback.UserId = user.Id;
            feedback.Date = DateTime.Now;
            feedback.CreatedById = user.Id;
            feedback.CreatedDateUtc = DateTime.Now;

            var agent = await _unitOfWork.Repository<AgentProfile>().GetAsync(a => a.Id == feedback.AgentId);
            if (agent.Rating == 0) agent.Rating += feedback.Rating;
            else agent.Rating = (agent.Rating + feedback.Rating) / 2;

            await _unitOfWork.Repository<AgentProfile>().UpdateAsync(agent);
            await _unitOfWork.Repository<Feedback>().AddAsync(feedback);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetAgentByIdInfoDto> GetCurrentAgent()
        {
            var agent = await _authentication.GetCurrentUserAsync();
            var userAgent = await _unitOfWork.Repository<AgentProfile>().GetAsync(a => a.Id == agent.Id);
            var agentDto = _mapper.Map<GetAgentByIdInfoDto>(userAgent);
            agentDto.FeedBacks = null;
            agentDto.ImagePath = agent.ImagePath;
            agentDto.FirstName = agent.FirstName;
            agentDto.LastName = agent.LastName;
            return agentDto;
        }

        public async Task<List<FeedbackListDto>> GetCurrentAgentFeedbacks()
        {
            var agent = await _authentication.GetCurrentUserAsync();

            var feedbacksDto = new List<FeedbackListDto>();
            var feedbacks = await _unitOfWork.Repository<Feedback>().GetAllAsync(o => o.AgentId == agent.Id);

            foreach (var feedback in feedbacks)
            {
                var feedbackDto = _mapper.Map<FeedbackListDto>(feedback);
                var user = await _userManager.FindByIdAsync(feedback.UserId);
                feedbackDto.FirstName = user.FirstName;
                feedbackDto.LastName = user.LastName;
                feedbackDto.ImagePath = user.ImagePath;
                feedbacksDto.Add(feedbackDto);
            }

            return feedbacksDto;
        }

    }



}
