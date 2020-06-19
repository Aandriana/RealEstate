using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace RealEstate.BLL.DTO
{
    public class PropertyUpdatePhotosDto
    {
        public ICollection<IFormFile> AddedContentImages { get; set; }
        public ICollection<string> NotDeletedContentImageUrls { get; set; }
    }
}
