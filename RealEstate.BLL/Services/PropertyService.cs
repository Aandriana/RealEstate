using AutoMapper;
using Common.Enums;
using Common.FilterClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.BLL.DTO;
using RealEstate.BLL.Interfaces;
using RealEstate.DAL.Entities;
using RealEstate.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.BLL.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IAuthenticationService _authentication;
        private readonly IMapper _mapper;
        private readonly IOfferService _offerService;

        public PropertyService(IUnitOfWork unitOfWork, IFileService fileService, IAuthenticationService authentication, IMapper mapper, IOfferService offerService)
        {
            _authentication = authentication;
            _fileService = fileService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _offerService = offerService;
        }

        public async Task AddProperty([FromForm]PropertyCreateDto propertyDto)
        {
            var user = await _authentication.GetCurrentUserAsync();

            var property = _mapper.Map<Property>(propertyDto);
            property.Photos = new List<PropertyPhoto>();

            foreach (var image in propertyDto.Photos)
            {
                property.Photos.Add(await UploadImage(image));
            }

            property.Status = (int)PropertyStatus.LookingForAgent;
            property.CreatedById = user.Id;
            property.UserId = user.Id;
            await _unitOfWork.Repository<Property>().AddAsync(property);
            await _unitOfWork.SaveChangesAsync();

            foreach (var agentId in propertyDto.AgentsId)
            {
                var offer = new Offer();
                offer.AgentProfileId = agentId;
                offer.PropertyId = property.Id;
                offer.CreatedById = user.Id;
                await _unitOfWork.Repository<Offer>().AddAsync(offer);
            }

            foreach (var questionDto in propertyDto.QuestionsDtos)
            {
                var question = _mapper.Map<Question>(questionDto);
                question.CreatedById = user.Id;
                question.PropertyId = property.Id;
                question.CreatedDateUtc = DateTime.Now;
                await _unitOfWork.Repository<Question>().AddAsync(question);
            }
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteProperty(int id)
        {
            var property = await _unitOfWork.Repository<Property>().GetAsync(p => p.Id == id);

            if (property == null) throw new NullReferenceException();
            var user = await _authentication.GetCurrentUserAsync();
            if (property.UserId != user.Id) throw new AccessViolationException();

            property.Status = (int)PropertyStatus.Frozen;
            await _unitOfWork.Repository<Property>().UpdateAsync(property);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateProperty(int id, PropertyUpdateDto property)
        {
            var propertyToUpdate = await _unitOfWork.Repository<Property>().GetIncludingAll(p => p.Id == id);
            if (propertyToUpdate == null) throw new NullReferenceException();
            var user = await _authentication.GetCurrentUserAsync();
            if (propertyToUpdate.UserId != user.Id) throw new AccessViolationException();

            propertyToUpdate.Address = property.Address;
            propertyToUpdate.BuildYear = property.BuildYear;
            propertyToUpdate.City = property.City;
            propertyToUpdate.UpdatedById = user.Id;
            propertyToUpdate.FloorsNumber = property.FloorsNumber;
            propertyToUpdate.Price = property.Price;
            propertyToUpdate.Size = property.Size;
            propertyToUpdate.Сategory = property.Сategory;
            propertyToUpdate.Floors = property.Floors;
            propertyToUpdate.UpdatedById = user.Id;
            propertyToUpdate.UpdatedDateUtc = DateTime.Now;

            await _unitOfWork.Repository<Property>().UpdateAsync(propertyToUpdate);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdatePhotos(int id, PropertyUpdatePhotosDto photosDto)
        {
            var propertyToUpdate = await _unitOfWork.Repository<Property>().GetIncludingAll(p => p.Id == id);
            if (propertyToUpdate == null) throw new NullReferenceException();
            var user = await _authentication.GetCurrentUserAsync();
            if (propertyToUpdate.UserId != user.Id) throw new AccessViolationException();

            if (propertyToUpdate.Photos != null)
            {
                foreach (var photos in propertyToUpdate.Photos)
                {
                    if (!photosDto.NotDeletedContentImageUrls.Contains(photos.Path))
                    {
                        await DeleteImage(photos);
                    }
                }
            }

            if (photosDto.AddedContentImages != null)
            {
                foreach (var photos in photosDto.AddedContentImages)
                {
                    propertyToUpdate.Photos.Add(await UploadImage(photos));
                }
            }

            await _unitOfWork.Repository<Property>().UpdateAsync(propertyToUpdate);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddNewQuestions(int propertyId, AddQuestionDto questionsDto)
        {
            var propertyToUpdate = await _unitOfWork.Repository<Property>().GetAsync(p => p.Id == propertyId);
            var user = await _authentication.GetCurrentUserAsync();
            if (propertyToUpdate.UserId != user.Id) throw new FieldAccessException();

            foreach (var questionDto in questionsDto.Questions)
            {
                var question = _mapper.Map<Question>(questionDto);
                question.PropertyId = propertyId;
                question.CreatedById = user.Id;
                await _unitOfWork.Repository<Question>().AddAsync(question);
            }

            await _unitOfWork.SaveChangesAsync();
        }


        public async Task RestoreProperty(int id)
        {
            var property = await _unitOfWork.Repository<Property>().GetAsync(p => p.Id == id);
            if (property == null) throw new NullReferenceException();
            var user = await _authentication.GetCurrentUserAsync();
            if (property.UserId != user.Id) throw new AccessViolationException();

            property.Status = (int)PropertyStatus.LookingForAgent;

            await _unitOfWork.Repository<Property>().UpdateAsync(property);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<IEnumerable<PropertyListDto>> GetPropertiesForUser(PropertyListFilter filter)
        {
            var user = await _authentication.GetCurrentUserAsync();
            var properties = await GetFilteredProperties(filter, user.Id);
            var propertiesDto = new List<PropertyListDto>();

            foreach (var property in properties)
            {
                var propertyDto = _mapper.Map<PropertyListDto>(property);
                var photo = await _unitOfWork.Repository<PropertyPhoto>().GetAsync(p => p.PropertyId == property.Id);
                if(photo != null)
                propertyDto.Image = photo.Path;
                propertiesDto.Add(propertyDto);
            }

            return propertiesDto;
        }

        public async Task<IEnumerable<PropertyListDto>> GetPropertiesForAgent(PaginationParameters paginationParameters)
        {
            var properties = await _unitOfWork.Repository<Property>().GetAllAsync(p => p.Status == (int)PropertyStatus.LookingForAgent);
            properties = properties.Skip(paginationParameters.Skip).Take(paginationParameters.Take);
            var propertiesDto = new List<PropertyListDto>();

            foreach (var property in properties)
            {
                var propertyDto = _mapper.Map<PropertyListDto>(property);
                propertiesDto.Add(propertyDto);
            }

            return propertiesDto;
        }

        public async Task<GetPropertyDto> GetPropertyById(int id)
        {
            var user = await _authentication.GetCurrentUserAsync();
            var userRoles = await _authentication.GetCurrentUserRolesAsync(user);
            var userIsAgent = false;

            foreach (var role in userRoles)
            {
                if (role == "Agent") userIsAgent = true;
            }

            var property = await _unitOfWork.Repository<Property>().GetIncludingAll(p => p.Id == id);

            if (!userIsAgent && property.UserId != user.Id) throw new FieldAccessException();
            var propertyDto = _mapper.Map<GetPropertyDto>(property);

            return propertyDto;
        }

        public async Task<List<OfferDto>> GetPropertyOffers(int id, OfferListFilter offerFilter)
        {
            var user = await _authentication.GetCurrentUserAsync();
            var propepty = await _unitOfWork.Repository<Property>().GetAsync(p => p.Id == id);
            if (propepty.UserId != user.Id) throw new FieldAccessException();

            var offers = await GetFilteredOffersForUser(offerFilter, id);
            var offerDtos = new List<OfferDto>();
            foreach (var offer in offers)
            {
                var offerDto = _mapper.Map<OfferDto>(offer);
                offerDtos.Add(offerDto);
            }
            return offerDtos;
        }

        private async Task<List<Property>> GetFilteredProperties(PropertyListFilter filter, string userId)
        {
            var properties = await _unitOfWork.Repository<Property>().GetAllAsync(p => p.UserId == userId);
            if (filter.Status != null && filter.Category != null)
            {
                properties = properties.Where(p => p.Status == filter.Status && p.Сategory == filter.Category);
            }

            if (filter.Status == null && filter.Category != null)
            {
                properties = properties.Where(p => p.Сategory == filter.Category);
            }

            if (filter.Status != null && filter.Category == null)
            {
                properties = properties.Where(p => p.Status == filter.Status);
            }
            return await properties.Skip(filter.Skip).Take(filter.Take).ToListAsync();
        }

        private async Task<List<Offer>> GetFilteredOffersForUser(OfferListFilter filter, int propertyId)
        {
            var offers = await _unitOfWork.Repository<Offer>().GetAllAsync(o => o.PropertyId == propertyId);

            if (filter.OfferStatus != null)
            {
                offers = offers.Where(p => p.Status == filter.OfferStatus);
            }

            return await offers.Skip(filter.Skip).Take(filter.Take).ToListAsync();
        }

        private async Task<PropertyPhoto> UploadImage(IFormFile image)
        {
            if (image == null) throw new ArgumentNullException();

            using (var fileStream = image.OpenReadStream())
            {
                var imageExtension = Path.GetExtension(image.FileName);
                var imageUrl = await _fileService.SaveFile(fileStream, imageExtension);
                var uploadedImage = new PropertyPhoto() { Path = imageUrl.ToString() };
                return uploadedImage;
            }
        }
        private async Task DeleteImage(PropertyPhoto photo)
        {
            await DeleteImageFile(photo.Path);
            _unitOfWork.Repository<PropertyPhoto>().Remove(photo);
        }

        private async Task DeleteImageFile(string path)
        {
            await _fileService.RemoveFile(path);
        }
    }
}
