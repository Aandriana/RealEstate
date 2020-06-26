using Microsoft.AspNetCore.Http;

namespace RealEstateIdentity.ViewModels.UserViewModels
{
    public class EditUserProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
        public EditAgentProfileViewModel AgentProfile { get; set; }
    }
}
