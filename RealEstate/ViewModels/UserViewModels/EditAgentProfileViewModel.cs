using System;

namespace RealEstateIdentity.ViewModels.UserViewModels
{
    public class EditAgentProfileViewModel
    {
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public double DefaultRate { get; set; }
    }
}
