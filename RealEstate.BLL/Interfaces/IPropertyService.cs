using Common.FilterClasses;
using RealEstate.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.BLL.Interfaces
{
    public interface IPropertyService
    {
        Task AddProperty(PropertyCreateDto propertyDto);
        Task DeleteProperty(int id);
        Task UpdateProperty(int id, PropertyUpdateDto property);
        Task RestoreProperty(int id);
        Task UpdatePhotos(int id, PropertyUpdatePhotosDto photosDto);
        Task<IEnumerable<PropertyListDto>> GetProperties(PropertyListFilter filter);
        Task<GetPropertyDto> GetPropertyById(int id);
        Task<List<OfferDto>> GetPropertyOffers(int id, OfferListFilter offerFilter);
        Task UpdateQuestions(int id, QuestionsUpdateDto questions);
    }
}
