using AutoMapper;
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
   public class PropertyService: IPropertyService
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

            await _unitOfWork.Repository<Property>().AddAsync(property);
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
    }
}
