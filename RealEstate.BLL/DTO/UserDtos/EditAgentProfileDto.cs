using System;

namespace RealEstate.BLL.DTO
{
    public class EditAgentProfileDto
    {
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public double DefaultRate { get; set; }
    }
}
