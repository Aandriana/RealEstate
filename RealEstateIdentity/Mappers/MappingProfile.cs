using AutoMapper;
using RealEstate.DAL.Entities;
using RealEstateIdentity.ViewModels;

namespace RealEstateIdentity.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterViewModel, User>()
                .ForMember(u => u.FirstName, map => map.MapFrom(vm => vm.FirstName))
                .ForMember(u => u.LastName, map => map.MapFrom(vm => vm.LastName))
                .ForMember(u => u.Email, map => map.MapFrom(vm => vm.Email))
                .ForMember(u => u.PhoneNumber, map => map.MapFrom(vm => vm.PhoneNumber))
                .ForMember(u => u.ImagePath, map => map.Ignore())
                .ForMember(u => u.UserName, mqp => mqp.MapFrom(vm => vm.Email));

            CreateMap<UserDetailsViewModel, User>()
                     .ForMember(u => u.FirstName, map => map.MapFrom(vm => vm.FirstName))
                     .ForMember(u => u.LastName, map => map.MapFrom(vm => vm.LastName))
                     .ForMember(u => u.Email, map => map.MapFrom(vm => vm.Email))
                     .ForMember(u => u.PhoneNumber, map => map.MapFrom(vm => vm.PhoneNumber))
                     .ForMember(u => u.ImagePath, map => map.Ignore())
                     .ForMember(u => u.UserName, mqp => mqp.MapFrom(vm => vm.Email));

            CreateMap<User, UserDetailsViewModel>()
                     .ForMember(u => u.FirstName, map => map.MapFrom(vm => vm.FirstName))
                       .ForMember(u => u.LastName, map => map.MapFrom(vm => vm.LastName))
                       .ForMember(u => u.Email, map => map.MapFrom(vm => vm.Email))
                       .ForMember(u => u.PhoneNumber, map => map.MapFrom(vm => vm.PhoneNumber))
                       .ForMember(u => u.Image, map => map.Ignore());
        }
    }
}
