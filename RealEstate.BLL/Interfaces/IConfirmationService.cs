using RealEstate.BLL.DTO;
using System.Threading.Tasks;

namespace RealEstate.BLL.Interfaces
{
    public interface IConfirmationService
    {
        Task SendEmail(string token, string userEmail, string pathTo);
        Task<bool> ConfirmUser(ConfirmUserDto confirmUser);
    }
}
