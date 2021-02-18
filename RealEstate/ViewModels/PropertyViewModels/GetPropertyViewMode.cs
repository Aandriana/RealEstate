using RealEstateIdentity.ViewModels;
using RealEstateIdentity.ViewModels.OfferViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.ViewModels
{
    public class GetPropertyViewMode
    {
        public double Size { get; set; }
        public int Category { get; set; }
        public int FloorsNumber { get; set; }
        public int Floors { get; set; }
        public double Price { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int BuildYear { get; set; }
        public int Status { get; set; }
        public virtual ICollection<OfferViewModel> Offers { get; set; }
        public virtual ICollection<string> Photos { get; set; }
        public virtual ICollection<QuestionViewModel> Questions { get; set; }
    }
}
