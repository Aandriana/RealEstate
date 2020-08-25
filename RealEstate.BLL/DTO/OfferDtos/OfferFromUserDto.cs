using System.Collections.Generic;

namespace RealEstate.BLL.DTO
{
    public class OfferFromUserDto
    {
        public virtual ICollection<int> PropertyId { get; set; }
        public string AgentProfileId { get; set; }
    }
}
