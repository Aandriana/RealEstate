using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using RealEstate.DAL.UnitOfWork;
using RealEstate.BLL.Interfaces;
using RealEstate.BLL.DTO.UserDtos;

namespace RealEstate.BLL.Services
{
   public class EmailService : IEmailService
    {
        private readonly ISendGridClient _emailClient;

        public EmailService(ISendGridClient emailClient)
        {
            _emailClient = emailClient;
        }

        public async Task SendEmail(EmailDto emailDto)
        {
            var msg = MailHelper.CreateSingleEmail(emailDto.From, emailDto.To, emailDto.Subject, "", emailDto.HtmlContent);
            var response = await _emailClient.SendEmailAsync(msg);
        }
    }
}
