using Common.FilterClasses;
using RealEstate.BLL.DTO;
using RealEstate.BLL.DTO.UserDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.BLL.Interfaces
{
    public interface IUserService
    {
        Task<string> Login(LoginDto model);
        Task<string> Register(RegisterDto model);
        Task<string> AgentRegister(AgentRegisterDto agentRegister);
        Task<string> EditUser(UserDetailsDto editUser);
        Task<UserDetailsDto> GetMyInfo();
        Task<List<UsersListDto>> GetAllAgents(PaginationParameters pagination);
        Task<string> EditAgentProfile(EditUserProfileDto editUser);
        Task<GetAgentByIdInfoDto> GetAgentById(string agentId);
        Task AddFeedBackForAgent(FeedBackDto feedBackDto);
        Task<GetAgentByIdInfoDto> GetCurrentAgent();
        Task<List<FeedbackListDto>> GetCurrentAgentFeedbacks();
    }
}
