using RealEstate.BLL.DTO.UserDtos;
using RealEstate.DAL.Entities;
using SendGrid.Helpers.Mail;
using System.Web;

namespace RealEstate.BLL.Helpers
{
    public static class EmailSendingHelper
    {
        public static EmailDto RegisterEmail(string code, string body, User user, string from, string url)
        {
            var codeHtmlVersion = HttpUtility.UrlEncode(code);
            body = body.Replace("{ID}", user.Id);
            body = body.Replace("{CODE}", codeHtmlVersion);
            body = body.Replace("{FIRSTNAME}", user.FirstName);
            body = body.Replace("{URL}", url);

            var sender = new EmailAddress(from, "RealEstate");
            var to = new EmailAddress(user.Email);

            var emailDto = new EmailDto();
            emailDto.HtmlContent = body;
            emailDto.Subject = "RealEstate";
            emailDto.To = to;
            emailDto.From = sender;

            return emailDto;
        }
        public static EmailDto ForgotPasswordEmail(string code, string body, User user, string from, string url)
        {
            var codeHtmlVersion = HttpUtility.UrlEncode(code);
            body = body.Replace("{ID}", user.Id);
            body = body.Replace("{CODE}", codeHtmlVersion);
            body = body.Replace("{URL}", url);

            var sender = new EmailAddress(from, "RealEstate");
            var to = new EmailAddress(user.Email);

            var emailDto = new EmailDto();
            emailDto.HtmlContent = body;
            emailDto.Subject = "RealEstate";
            emailDto.To = to;
            emailDto.From = sender;

            return emailDto;
        }
    }
}
