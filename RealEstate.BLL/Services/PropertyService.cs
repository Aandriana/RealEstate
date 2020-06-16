using AutoMapper;
using Common.Enums;
using Microsoft.AspNetCore.Http;
using RealEstate.BLL.DTO;
using RealEstate.BLL.Interfaces;
using RealEstate.DAL.Entities;
using RealEstate.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RealEstate.BLL.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IAuthenticationService _authentication;

        public PropertyService(IUnitOfWork unitOfWork, IFileService fileService, IAuthenticationService authentication)
        {
            _authentication = authentication;
            _fileService = fileService;
            _unitOfWork = unitOfWork;
        }

        public async Task AddProperty(PropertyCreateDto propertyDto)
        {
            var user = await _authentication.GetCurrentUserAsync();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PropertyCreateDto, Property>()
               .ForMember(p => p.UserId, pdto => pdto.MapFrom(u => user.Id)))
                .CreateMapper();

            var property = mapper.Map<PropertyCreateDto, Property>(propertyDto);
            property.Photos = new List<PropertyPhoto>();

            foreach (var image in propertyDto.PhotosDtos)
            {
                property.Photos.Add(await UploadImage(image));
            }

            property.Status = (int)PropertyStatus.Frozen;
            property.CreatedById = user.Id;

            await _unitOfWork.Repository<Property>().AddAsync(property);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteProperty(int id)
        {
            var property = await _unitOfWork.Repository<Property>().GetAsync(p => p.Id == id);

            if (property == null) throw new NullReferenceException();
            var user = await _authentication.GetCurrentUserAsync();
            if (property.UserId != user.Id) throw new AccessViolationException();

            property.Status = (int)PropertyStatus.ForSale;
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

            if (propertyToUpdate.Photos != null)
            {
                foreach (var photos in propertyToUpdate.Photos)
                {
                    if (!property.NotDeletedContentImageUrls.Contains(photos.Path))
                    {
                        await DeleteImage(photos);
                    }
                }
            }

            if (property.AddedContentImages != null)
            {
                foreach (var photos in property.AddedContentImages)
                {
                    propertyToUpdate.Photos.Add(await UploadImage(photos));
                }
            }

            await _unitOfWork.Repository<Property>().UpdateAsync(propertyToUpdate);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RestoreProperty(int id)
        {
            var property = await _unitOfWork.Repository<Property>().GetAsync(p => p.Id == id);
            if (property == null) throw new NullReferenceException();
            var user = await _authentication.GetCurrentUserAsync();
            if (property.UserId != user.Id) throw new AccessViolationException();

            property.Status = (int)PropertyStatus.ForSale;

            await _unitOfWork.Repository<Property>().UpdateAsync(property);
            await _unitOfWork.SaveChangesAsync();
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
