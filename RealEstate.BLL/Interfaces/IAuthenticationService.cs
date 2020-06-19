using RealEstate.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GenerateJwtToken(User user);
        Task<User> GetCurrentUserAsync();
        Task<IList<string>> GetCurrentUserRolesAsync(User user);
    }
}
