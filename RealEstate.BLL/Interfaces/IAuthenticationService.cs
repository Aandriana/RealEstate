using Microsoft.AspNetCore.Identity;
using RealEstate.DAL.Entities;
using System.Threading.Tasks;

namespace RealEstate.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GenerateJwtToken(User user);
        Task<User> GetCurrentUserAsync();
    }
}
