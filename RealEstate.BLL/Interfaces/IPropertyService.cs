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
        Task<List<string>> GetPhotos(int id);
        Task UpdatePhotos(int id, PropertyUpdatePhotosDto photosDto);
        Task AddNewQuestions(int propertyId, QuestionUpdateDto questionsDto);
        Task<GetPropertyDto> GetPropertyByIdForUser(int id);
        Task<List<GetQuestionDto>> GetQuestions(int id);
        Task<GetPropertyDto> GetPropertyByIdForAgent(int id);
        Task<IEnumerable<PropertyListDto>> GetPropertiesForUser(PropertyListFilter filter);
        Task<IEnumerable<PropertyListDto>> GetPropertiesForAgent(PaginationParameters paginationParameters);
        Task<List<OfferDto>> GetPropertyOffers(int id, OfferListFilter offerFilter);
    }
}
