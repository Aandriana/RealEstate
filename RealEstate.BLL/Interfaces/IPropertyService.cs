﻿using Common.FilterClasses;
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
        Task AddNewQuestions(int propertyId, AddQuestionDto questionsDto);
        Task<GetPropertyDto> GetPropertyById(int id);
        Task<IEnumerable<PropertyListDto>> GetPropertiesForUser(PropertyListFilter filter);
        Task<IEnumerable<PropertyListDto>> GetPropertiesForAgent(PaginationParameters paginationParameters);
        Task<List<OfferDto>> GetPropertyOffers(int id, OfferListFilter offerFilter);
    }
}