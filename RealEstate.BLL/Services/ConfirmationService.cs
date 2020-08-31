using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;
using Common.Configurations;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using RealEstate.DAL.UnitOfWork;
using RealEstate.DAL.Entities;
using RealEstate.BLL.Interfaces;
using RealEstate.BLL.DTO;
using Microsoft.AspNetCore.Identity;
using System.Web;

namespace RealEstate.BLL.Services
{
   public class ConfirmationService : IConfirmationService
    {
        private readonly IHostingEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;
        private readonly EmailSettings _emailSettings;
        private readonly ISendGridClient _emailClient;
        private readonly UserManager<User> _userManager;

        public ConfirmationService(IHostingEnvironment env, IUnitOfWork unitOfWork, IOptions<EmailSettings> emailSettings, ISendGridClient emailClient, UserManager<User> userManager)
        {
            _env = env;
            _unitOfWork = unitOfWork;
            _emailSettings = emailSettings.Value;
            _emailClient = emailClient;
            _userManager = userManager;
        }

        public async Task SendEmail(string code, string userEmail, string pathTo)
        {
            string body = string.Empty;
            using (StreamReader reader =
            new StreamReader(Path.Combine(_env.ContentRootPath, "Templates", pathTo)))
            {
                body = await reader.ReadToEndAsync();
            }

            var user = await _unitOfWork.Repository<User>().GetAsync(u => u.Email == userEmail);
            var url = "https://realestate20200708014452.azurewebsites.net";
            if (_env.IsDevelopment())
            {
                url = "http://localhost:4200";
            }

            body = body.Replace("{ID}", user.Id);
            body = body.Replace("{CODE}", code);
            body = body.Replace("{FIRSTNAME}", user.FirstName);
            body = body.Replace("{URL}", url);  

            var from = new EmailAddress(_emailSettings.Email, "RealEstate");
            var to = new EmailAddress(userEmail);

            var subject = "RealEstate";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", body);
            var response = await _emailClient.SendEmailAsync(msg);
        } 
        public async Task<bool> ConfirmUser(ConfirmUserDto confirmUser)
        {
            if (confirmUser.Id == null || confirmUser.Code == null)
            {
                return false;
            }
            var user = await _unitOfWork.Repository<User>().GetAsync(u => u.Id == confirmUser.Id);
            if(user == null)
            {
                return false;
            }
            var code = HttpUtility.UrlEncode(confirmUser.Code);
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return true;
            }
                return false;
        }
    }
}
