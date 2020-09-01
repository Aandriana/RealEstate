using SendGrid.Helpers.Mail;

namespace RealEstate.BLL.DTO.UserDtos
{
    public class EmailDto
    {
       public EmailAddress From { get; set; }
        public EmailAddress To { get; set; }
        public string Subject { get; set; }
        public string PlainTextContent { get; set; }
        public string HtmlContent { get; set; }
    }
}
