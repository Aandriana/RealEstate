using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace RealEstateIdentity.ViewModels
{
    public class PropertyUpdatePhotosViewModel
    {
        public ICollection<IFormFile> AddedContentImages { get; set; }
        public ICollection<string> NotDeletedContentImageUrls { get; set; }
    }
}
