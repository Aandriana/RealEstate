using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace RealEstateIdentity.ViewModels
{
    public class PropertyCreateViewModel
    {
        public double Size { get; set; }
        public int Сategory { get; set; }
        public int FloorsNumber { get; set; }
        public int Floors { get; set; }
        public double Price { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int BuildYear { get; set; }
        public ICollection<OfferFromUserViewModel> Offers { get; set; }
        public virtual ICollection<IFormFile> Photos { get; set; }
        public virtual ICollection<QuestionViewModel> Questions { get; set; }
    }
}
