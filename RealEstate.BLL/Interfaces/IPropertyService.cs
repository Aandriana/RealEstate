using Microsoft.AspNetCore.Http;
using RealEstate.BLL.DTO;
using RealEstate.DAL.Entities;
using System.Threading.Tasks;

namespace RealEstate.BLL.Interfaces
{
    public interface IPropertyService
    {
        Task AddProperty(PropertyCreateDto propertyDto);
        Task DeleteProperty(int id);
        Task UpdateProperty(int id, PropertyUpdateDto property);
        Task RestoreProperty(int id);
    }
}
