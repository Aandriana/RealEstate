﻿using AutoMapper;
using Common.Enums;
using Common.Exceptions;
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

        public PropertyService(IUnitOfWork unitOfWork, IFileService fileService, IAuthenticationService authentication, IMapper mapper)
        {
            _authentication = authentication;
            _fileService = fileService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
                var agent = await _unitOfWork.Repository<AgentProfile>().GetAsync(a => a.Id == agentId);
                var offer = new Offer();
                offer.AgentProfileId = agentId;
                offer.PropertyId = property.Id;
                offer.CreatedById = user.Id;
                offer.Rate = agent.DefaultRate;
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
            propertyToUpdate.Category = property.Сategory;
            propertyToUpdate.Floors = property.Floors;
            propertyToUpdate.UpdatedById = user.Id;
            propertyToUpdate.UpdatedDateUtc = DateTime.Now;

            await _unitOfWork.Repository<Property>().UpdateAsync(propertyToUpdate);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<List<string>> GetPhotos(int id)
        {
            var photos = new List<string>();
            var propertyPhotos = await _unitOfWork.Repository<PropertyPhoto>().GetAllAsync(p => p.PropertyId == id);
            foreach (var photo in propertyPhotos)
            {
                photos.Add(photo.Path);
            }
            return photos;
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

        public async Task AddNewQuestions(int propertyId, QuestionUpdateDto questionsDto)
        {
            var propertyToUpdate = await _unitOfWork.Repository<Property>().GetAsync(p => p.Id == propertyId);
            var user = await _authentication.GetCurrentUserAsync();
            if (propertyToUpdate.UserId != user.Id) throw new FieldAccessException();

            var question = _mapper.Map<Question>(questionsDto);
            question.CreatedById = user.Id;
            question.PropertyId = propertyId;
            question.CreatedDateUtc = DateTime.Now;
            await _unitOfWork.Repository<Question>().AddAsync(question);
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
                if (photo != null)
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

            foreach(var property in propertiesDto)
            {
                var photo = await _unitOfWork.Repository<PropertyPhoto>().GetAsync(p => p.PropertyId == property.Id);
                if (photo != null)
                    property.Image = photo.Path;
            }

            return propertiesDto;
        }

        public async Task<GetPropertyDto> GetPropertyByIdForUser(int id)
        {
            var user = await _authentication.GetCurrentUserAsync();
            var property = await _unitOfWork.Repository<Property>().GetIncludingAll(p => p.Id == id) ?? throw new NotFoundException("Property");
            if (property.UserId != user.Id) throw new NoPermissionsException("You don't have permission for get this priperty as you dont't own");
            var propertyDto = _mapper.Map<GetPropertyDto>(property);
            if (propertyDto.OfferDtos != null)
            {
                foreach (var offer in propertyDto.OfferDtos)
                {
                    var agent = await _unitOfWork.Repository<User>().GetAsync(u => u.Id == offer.AgentProfileId);
                    offer.Image = agent.ImagePath;
                    offer.FirstName = agent.FirstName;
                    offer.LastName = agent.LastName;
                }
            }
            propertyDto.OfferDtos = propertyDto.OfferDtos.Take(5).ToList();
            return propertyDto;
        }

        public async Task<GetPropertyDto> GetPropertyByIdForAgent(int id)
        {
            var property = await _unitOfWork.Repository<Property>().GetIncludingAll(p => p.Id == id) ?? throw new NotFoundException("Property");
            var propertyDto = _mapper.Map<GetPropertyDto>(property);
            propertyDto.OfferDtos = null;
            return propertyDto;
        }
        public async Task<List<OfferDto>> GetPropertyOffers(int id, OfferListFilter offerFilter)
        {
            var user = await _authentication.GetCurrentUserAsync();
            var propepty = await _unitOfWork.Repository<Property>().GetAsync(p => p.Id == id) ?? throw new NotFoundException("Property");
            if (propepty.UserId != user.Id) throw new FieldAccessException();

            var offers = await GetFilteredOffersForUser(offerFilter, id);
            var offerDtos = new List<OfferDto>();
            foreach (var offer in offers)
            {
                var agent = await _unitOfWork.Repository<User>().GetAsync(a => a.Id == offer.AgentProfileId);
                var offerDto = _mapper.Map<OfferDto>(offer);
                offerDto.Image = agent.ImagePath;
                offerDto.FirstName = agent.FirstName;
                offerDto.LastName = agent.LastName;
                offerDto.AgentProfileId = agent.Id;
                var answers = await _unitOfWork.Repository<Answer>().GetAllAsync(a => a.OfferId == offer.Id);
                foreach (var answer in answers)
                {
                    var answerDto = _mapper.Map<AnswerDto>(answer);
                    offerDto.Answers.Add(answerDto);

                }
                offerDtos.Add(offerDto);
            }
            return offerDtos;
        }

        public async Task<List<GetQuestionDto>> GetQuestions(int id)
        {
            var questions = await _unitOfWork.Repository<Question>().GetAllAsync(q => q.PropertyId == id);
            var questionsDto = new List<GetQuestionDto>();

            foreach (var question in questions)
            {
                var questionDto = _mapper.Map<GetQuestionDto>(question);
                questionsDto.Add(questionDto);
            }
            return questionsDto;
        }

        private async Task<List<Property>> GetFilteredProperties(PropertyListFilter filter, string userId)
        {
            var properties = await _unitOfWork.Repository<Property>().GetAllAsync(p => p.UserId == userId);
            if (filter.Status != null && filter.Category != null)
            {
                properties = properties.Where(p => p.Status == filter.Status && p.Category == filter.Category);
            }

            if (filter.Status == null && filter.Category != null)
            {
                properties = properties.Where(p => p.Category == filter.Category);
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
