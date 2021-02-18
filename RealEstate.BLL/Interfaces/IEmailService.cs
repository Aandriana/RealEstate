using RealEstate.BLL.DTO;
using RealEstate.BLL.DTO.UserDtos;
using System.Threading.Tasks;

namespace RealEstate.BLL.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(EmailDto emailDto);
    }
}
