using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace RealEstate.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GenerateJwtToken(string email, IdentityUser user);
    }
}
