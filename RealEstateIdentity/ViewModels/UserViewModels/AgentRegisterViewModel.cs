using Microsoft.AspNetCore.Http;

namespace RealEstateIdentity.ViewModels
{
    public class AgentRegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile Image { get; set; }
        public AgentRegisterProfileViewModel AgentProfile { get; set; }
    }
}
