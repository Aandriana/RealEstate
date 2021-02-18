using System.Collections.Generic;

namespace RealEstateIdentity.ViewModels
{
    public class OfferFromUserViewModel
    {
        public virtual ICollection<int> PropertyId { get; set; }
        public string AgentProfileId { get; set; }
    }
}
