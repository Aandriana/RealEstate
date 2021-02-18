using AutoMapper;
using Common.Configurations;
using Common.Exceptions;
using Common.FilterClasses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using RealEstate.BLL.DTO;
using RealEstate.BLL.DTO.UserDtos;
using RealEstate.BLL.Helpers;
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
        private readonly IEmailService _confirmationService;
        private readonly IHostingEnvironment _env;
        private readonly EmailSettings _emailSettings;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IAuthenticationService authentication, IMapper mapper, IFileService fileService, IUnitOfWork unitOfWork, IEmailService confirmationService, IHostingEnvironment env, IOptions<EmailSettings> emailSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authentication = authentication;
            _mapper = mapper;
            _fileService = fileService;
            _unitOfWork = unitOfWork;
            _confirmationService = confirmationService;
            _env = env;
            _emailSettings = emailSettings.Value;
        }

        public async Task<string> Login(LoginDto model)
        {
            var user = await _unitOfWork.Repository<User>().GetAsync(u => u.Email == model.Email);
          //  if (!user.EmailConfirmed) return null;
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                var token = await _authentication.GenerateJwtToken(appUser);
                return token;
            }
            return null;
        }

        public async Task Register(RegisterDto model)
        {
            var user = _mapper.Map<User>(model);
            user.ImagePath = model.ImagePath;
            user.EmailConfirmed = true;
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var currentUser = await _userManager.FindByNameAsync(user.UserName);
                await _userManager.AddToRoleAsync(currentUser, "User");
                string body = string.Empty;
                using (StreamReader reader =
                new StreamReader(Path.Combine(_env.ContentRootPath, "Templates", "Welcome.html")))
                {
                    body = await reader.ReadToEndAsync();
                }
                var url = "https://realestate20200708014452.azurewebsites.net";

                if (_env.IsDevelopment())
                {
                    url = "http://localhost:4200";
                }
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var email = EmailSendingHelper.RegisterEmail(code, body, user, _emailSettings.Email, url);
                await _confirmationService.SendEmail(email);
            }
        }

        public async Task AgentRegister(AgentRegisterDto agentRegister)
        {
            var agent = _mapper.Map<User>(agentRegister);
            agent.ImagePath = agentRegister.ImagePath;
            agent.AgentProfile.Id = agent.Id;
            agent.EmailConfirmed = true;
            var result = await _userManager.CreateAsync(agent, agentRegister.Password);

            if (result.Succeeded)
            {
                var currentUser = await _userManager.FindByNameAsync(agent.UserName);
                await _userManager.AddToRoleAsync(currentUser, "Agent");
                string body = string.Empty;
                using (StreamReader reader =
                new StreamReader(Path.Combine(_env.ContentRootPath, "Templates", "Welcome.html")))
                {
                    body = await reader.ReadToEndAsync();
                }
                var url = "https://realestate20200708014452.azurewebsites.net";

                if (_env.IsDevelopment())
                {
                    url = "http://localhost:4200";
                }
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(agent);
                var email = EmailSendingHelper.RegisterEmail(code, body, agent, _emailSettings.Email, url);
                await _confirmationService.SendEmail(email);
            }
        }

        public async Task<bool> ConfirmUser(ConfirmUserDto confirmUser)
        {
            if (confirmUser.Id == null || confirmUser.Code == null)
            {
                return false;
            }
            var user = await _unitOfWork.Repository<User>().GetAsync(u => u.Id == confirmUser.Id);
            if (user == null)
            {
                return false;
            }
            var result = await _userManager.ConfirmEmailAsync(user, confirmUser.Code);
            return result.Succeeded;
        }

        public async Task<bool> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _unitOfWork.Repository<User>().GetAsync(u => u.Email == forgotPasswordDto.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                return false;
            }
            string body = string.Empty;
            using (StreamReader reader =
            new StreamReader(Path.Combine(_env.ContentRootPath, "Templates", "password.html")))
            {
                body = await reader.ReadToEndAsync();
            }
            var url = "https://realestate20200708014452.azurewebsites.net";

            if (_env.IsDevelopment())
            {
                url = "http://localhost:4200";
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var email = EmailSendingHelper.RegisterEmail(code, body, user, _emailSettings.Email, url);
            await _confirmationService.SendEmail(email);
            return true;
        }

        public async Task<bool> ResetPassword(ResetPasswordDto resetPassword)
        {
            var user = await _userManager.FindByIdAsync(resetPassword.Id);
            if (user == null)
            {
                return false;
            }
            var result = await _userManager.ResetPasswordAsync(user, resetPassword.Code, resetPassword.Password);
            return result.Succeeded;
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
            if (user == null) throw new UnauthorizedAccessException("Please authorize first");
            var userDetails = _mapper.Map<UserDetailsDto>(user);
            return userDetails;
        }

        public async Task<List<UsersListDto>> GetAllAgents(PaginationParameters pagination)
        {
            var users = await _userManager.GetUsersInRoleAsync("Agent") ?? throw new NotFoundException("There is no agents yet");
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
            }
            user.FirstName = editUser.FirstName;
            user.LastName = editUser.LastName;
            user.Email = editUser.Email;
            user.PhoneNumber = editUser.PhoneNumber;

            await _userManager.UpdateAsync(user);

            var agent = await _unitOfWork.Repository<AgentProfile>().GetAsync(a => a.Id == user.Id) ?? throw new InvalidArgumentException("Agent id", "No agents with such id");
            var usersDto = new List<UsersListDto>();
            agent.BirthDate = editUser.AgentProfile.BirthDate;
            agent.City = editUser.AgentProfile.City;
            agent.DefaultRate = editUser.AgentProfile.DefaultRate;
            agent.Description = editUser.AgentProfile.Description;

            await _unitOfWork.Repository<AgentProfile>().UpdateAsync(agent);
            await _unitOfWork.SaveChangesAsync();

            var currentUser = await _userManager.FindByNameAsync(user.UserName) ?? throw new NotFoundException(user.UserName);
            await _userManager.AddToRoleAsync(currentUser, "User");
            await _signInManager.SignInAsync(user, false);
            var token = await _authentication.GenerateJwtToken(user);
            return token;
        }

        public async Task<GetAgentByIdInfoDto> GetAgentById(string agentId)
        {
            var agent = await _unitOfWork.Repository<AgentProfile>().GetAsync(a => a.Id == agentId) ?? throw new NotFoundException("agent");
            var userAgent = await _userManager.FindByIdAsync(agentId) ?? throw new NotFoundException("user");
            var agentDto = _mapper.Map<GetAgentByIdInfoDto>(agent);
            var feedbacks = await _unitOfWork.Repository<Feedback>().GetAllAsync(o => o.AgentId == agentId);
            if (feedbacks != null)
            {
                foreach (var feedback in feedbacks)
                {
                    var feedbackDto = _mapper.Map<FeedbackListDto>(feedback);
                    agentDto.FeedBacks.Add(feedbackDto);
                }
                foreach (var feedback in agentDto.FeedBacks)
                {
                    var user = await GetUser(feedback.UserId);
                    feedback.FirstName = user.FirstName;
                    feedback.LastName = user.LastName;
                    feedback.ImagePath = user.Image;
                }

            }

            agentDto.ImagePath = userAgent.ImagePath;
            agentDto.FirstName = userAgent.FirstName;
            agentDto.LastName = userAgent.LastName;
            agentDto.Email = userAgent.Email;
            agentDto.PhoneNumber = userAgent.PhoneNumber;
            return agentDto;
        }

        private async Task<GetUser> GetUser(string id)
        {
            var user = await _unitOfWork.Repository<User>().GetAsync(u => u.Id == id) ?? throw new NotFoundException("user");
            var getUser = new GetUser();
            getUser.FirstName = user.FirstName;
            getUser.LastName = user.LastName;
            getUser.Image = user.ImagePath;
            return getUser;

        }
        public async Task AddFeedBackForAgent(FeedBackDto feedBackDto)
        {
            var user = await _authentication.GetCurrentUserAsync();
            var feedback = _mapper.Map<Feedback>(feedBackDto);
            feedback.UserId = user.Id;
            feedback.Date = DateTime.Now;
            feedback.CreatedById = user.Id;
            feedback.CreatedDateUtc = DateTime.Now;

            var agent = await _unitOfWork.Repository<AgentProfile>().GetAsync(a => a.Id == feedback.AgentId) ?? throw new NotFoundException("agent");
            if (agent.Rating == 0) agent.Rating += feedback.Rating;
            else agent.Rating = (agent.Rating + feedback.Rating) / 2;

            await _unitOfWork.Repository<AgentProfile>().UpdateAsync(agent);
            await _unitOfWork.Repository<Feedback>().AddAsync(feedback);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<GetAgentByIdInfoDto> GetCurrentAgent()
        {
            var agent = await _authentication.GetCurrentUserAsync();
            var userAgent = await _unitOfWork.Repository<AgentProfile>().GetAsync(a => a.Id == agent.Id) ?? throw new NotFoundException("agent");
            var agentDto = _mapper.Map<GetAgentByIdInfoDto>(userAgent);
            agentDto.FeedBacks = null;
            agentDto.ImagePath = agent.ImagePath;
            agentDto.FirstName = agent.FirstName;
            agentDto.LastName = agent.LastName;
            agentDto.Email = agent.Email;
            agentDto.PhoneNumber = agent.PhoneNumber;
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
