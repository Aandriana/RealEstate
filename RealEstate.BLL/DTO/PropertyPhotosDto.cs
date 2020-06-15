using Microsoft.AspNetCore.Http;

namespace RealEstate.BLL.DTO
{
    public class PropertyPhotosDto
    {
        public int PropertyId { get; set; }
        public IFormFile Image { get; set; }
    }
}
