using Microsoft.AspNetCore.Http;

namespace RealEstate.BLL.DTO
{
    public class EditUserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
        public EditAgentProfileDto AgentProfile { get; set; }
    }
}
