using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateIdentity.ViewModels
{
    public class PropertyUpdateViewModel
    {
        public double Size { get; set; }
        public int Сategory { get; set; }
        public int FloorsNumber { get; set; }
        public int Floors { get; set; }
        public double Price { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int BuildYear { get; set; }
        public ICollection<IFormFile> AddedContentImages { get; set; }
        public ICollection<string> NotDeletedContentImageUrls { get; set; }

    }
}
