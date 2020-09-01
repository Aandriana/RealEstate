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
using RealEstate.BLL.DTO.UserDtos;

namespace RealEstate.BLL.Services
{
   public class EmailService : IEmailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISendGridClient _emailClient;
        private readonly UserManager<User> _userManager;

        public EmailService( IUnitOfWork unitOfWork, ISendGridClient emailClient, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _emailClient = emailClient;
            _userManager = userManager;
        }

        public async Task SendEmail(EmailDto emailDto)
        {
            var msg = MailHelper.CreateSingleEmail(emailDto.From, emailDto.To, emailDto.Subject, "", emailDto.HtmlContent);
            var response = await _emailClient.SendEmailAsync(msg);
        }
    }
}
