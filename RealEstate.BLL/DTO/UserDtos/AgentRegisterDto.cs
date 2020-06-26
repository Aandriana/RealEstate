using Microsoft.AspNetCore.Http;

namespace RealEstate.BLL.DTO.UserDtos
{
   public  class AgentRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public AgentRegisterProfileDto AgentProfile { get; set; }
    }
}
