using AutoMapper;
using RealEstate.BLL.DTO;
using RealEstate.DAL.Entities;
using RealEstateIdentity.ViewModels;
using System.Linq;

namespace RealEstateIdentity.Mapping
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

            CreateMap<PropertyCreateViewModel, PropertyCreateDto>()
                .ForMember(p => p.Address, map => map.MapFrom(vm => vm.Address))
                .ForMember(p => p.Size, map => map.MapFrom(vm => vm.Size))
                .ForMember(p => p.Сategory, map => map.MapFrom(vm => vm.Сategory))
                .ForMember(p => p.FloorsNumber, map => map.MapFrom(vm => vm.FloorsNumber))
                .ForMember(p => p.Floors, map => map.MapFrom(vm => vm.Floors))
                .ForMember(p => p.Price, map => map.MapFrom(vm => vm.Price))
                .ForMember(p => p.City, map => map.MapFrom(vm => vm.City))
                .ForMember(p => p.BuildYear, map => map.MapFrom(vm => vm.BuildYear))
                .ForMember(p => p.OfferDtos, opt => opt.MapFrom(vm => vm.Offers.AsQueryable()))
                .ForMember(p => p.Photos, map => map.MapFrom(p => p.Photos))
                .ForMember(p => p.QuestionsDtos, map => map.MapFrom(vm => vm.Questions.AsQueryable()));

            CreateMap<PropertyUpdateViewModel, PropertyUpdateDto>()
               .ForMember(p => p.Address, map => map.MapFrom(vm => vm.Address))
                .ForMember(p => p.Size, map => map.MapFrom(vm => vm.Size))
                .ForMember(p => p.Сategory, map => map.MapFrom(vm => vm.Сategory))
                .ForMember(p => p.FloorsNumber, map => map.MapFrom(vm => vm.FloorsNumber))
                .ForMember(p => p.Floors, map => map.MapFrom(vm => vm.Floors))
                .ForMember(p => p.Price, map => map.MapFrom(vm => vm.Price))
                .ForMember(p => p.City, map => map.MapFrom(vm => vm.City))
                .ForMember(p => p.BuildYear, map => map.MapFrom(vm => vm.BuildYear))
                .ForMember(p => p.QuestionsDtos, map => map.MapFrom(p=> p.Questions.AsQueryable()));

            CreateMap<PropertyUpdatePhotosViewModel, PropertyUpdatePhotosDto>()
                .ForMember(p => p.NotDeletedContentImageUrls, map => map.MapFrom(vm => vm.NotDeletedContentImageUrls))
                .ForMember(p => p.AddedContentImages, map => map.MapFrom(vm => vm.AddedContentImages));

            CreateMap<PropertyCreateDto, Property>()
                .ForMember(p => p.Address, map => map.MapFrom(vm => vm.Address))
                .ForMember(p => p.Size, map => map.MapFrom(vm => vm.Size))
                .ForMember(p => p.Сategory, map => map.MapFrom(vm => vm.Сategory))
                .ForMember(p => p.FloorsNumber, map => map.MapFrom(vm => vm.FloorsNumber))
                .ForMember(p => p.Floors, map => map.MapFrom(vm => vm.Floors))
                .ForMember(p => p.Price, map => map.MapFrom(vm => vm.Price))
                .ForMember(p => p.City, map => map.MapFrom(vm => vm.City))
                .ForMember(p => p.BuildYear, map => map.MapFrom(vm => vm.BuildYear))
                .ForMember(p => p.Offers, map => map.MapFrom(p => p.OfferDtos.AsQueryable()))
                .ForMember(p => p.Photos, map => map.Ignore())
                .ForMember(p => p.Questions, map => map.MapFrom(o => o.QuestionsDtos.AsQueryable()));

            CreateMap<Property, PropertyCreateDto>()
                .ForMember(p => p.Address, map => map.MapFrom(vm => vm.Address))
                .ForMember(p => p.Size, map => map.MapFrom(vm => vm.Size))
                .ForMember(p => p.Сategory, map => map.MapFrom(vm => vm.Сategory))
                .ForMember(p => p.FloorsNumber, map => map.MapFrom(vm => vm.FloorsNumber))
                .ForMember(p => p.Floors, map => map.MapFrom(vm => vm.Floors))
                .ForMember(p => p.Price, map => map.MapFrom(vm => vm.Price))
                .ForMember(p => p.City, map => map.MapFrom(vm => vm.City))
                .ForMember(p => p.BuildYear, map => map.MapFrom(vm => vm.BuildYear))
                .ForMember(p => p.OfferDtos, map => map.MapFrom(p => p.Offers.AsQueryable()))
                .ForMember(p => p.Photos, map => map.Ignore())
                .ForMember(p => p.QuestionsDtos, map => map.MapFrom(p => p.Questions.AsQueryable())); ;

            CreateMap<Property, GetPropertyDto>()
    .ForMember(p => p.Address, map => map.MapFrom(vm => vm.Address))
    .ForMember(p => p.Size, map => map.MapFrom(vm => vm.Size))
    .ForMember(p => p.Сategory, map => map.MapFrom(vm => vm.Сategory))
    .ForMember(p => p.FloorsNumber, map => map.MapFrom(vm => vm.FloorsNumber))
    .ForMember(p => p.Floors, map => map.MapFrom(vm => vm.Floors))
    .ForMember(p => p.Price, map => map.MapFrom(vm => vm.Price))
    .ForMember(p => p.City, map => map.MapFrom(vm => vm.City))
    .ForMember(p => p.BuildYear, map => map.MapFrom(vm => vm.BuildYear))
    .ForMember(p => p.OfferDtos, map => map.MapFrom(p => p.Offers.AsQueryable()))
    .ForMember(p => p.PhotosDtos, opt => opt.MapFrom(vm => vm.Photos.Select(p => p.Path)))
    .ForMember(p => p.QuestionsDtos, map => map.MapFrom(p => p.Questions.AsQueryable()));

            CreateMap<PropertyListDto, PropertyListViewModel>()
                .ForMember(p => p.Address, map => map.MapFrom(vm => vm.Address))
                .ForMember(p => p.Size, map => map.MapFrom(vm => vm.Size))
                .ForMember(p => p.Сategory, map => map.MapFrom(vm => vm.Сategory))
                .ForMember(p => p.FloorsNumber, map => map.MapFrom(vm => vm.FloorsNumber))
                .ForMember(p => p.Floors, map => map.MapFrom(vm => vm.Floors))
                .ForMember(p => p.Price, map => map.MapFrom(vm => vm.Price))
                .ForMember(p => p.City, map => map.MapFrom(vm => vm.City))
                .ForMember(p => p.BuildYear, map => map.MapFrom(vm => vm.BuildYear));

            CreateMap<Property, PropertyListDto>()
                .ForMember(p => p.Address, map => map.MapFrom(vm => vm.Address))
                .ForMember(p => p.Size, map => map.MapFrom(vm => vm.Size))
                .ForMember(p => p.Сategory, map => map.MapFrom(vm => vm.Сategory))
                .ForMember(p => p.FloorsNumber, map => map.MapFrom(vm => vm.FloorsNumber))
                .ForMember(p => p.Floors, map => map.MapFrom(vm => vm.Floors))
                .ForMember(p => p.Price, map => map.MapFrom(vm => vm.Price))
                .ForMember(p => p.City, map => map.MapFrom(vm => vm.City))
                .ForMember(p => p.BuildYear, map => map.MapFrom(vm => vm.BuildYear));

            CreateMap<Offer, OfferPropertyAdedDto>()
                .ForMember(o => o.Comment, map => map.MapFrom(o => o.Comment))
                .ForMember(o => o.Rate, map => map.MapFrom(o => o.Rate));

            CreateMap<Answer, AnswerDto>()
                .ForMember(a => a.AnswerText, map => map.MapFrom(a => a.AnswerText))
                .ForMember(a => a.Question, map => map.MapFrom(a => a.Question));

            CreateMap<OfferPropertyAdedDto, Offer>()
                .ForMember(o => o.Comment, map => map.MapFrom(o => o.Comment))
                .ForMember(o => o.Answers, map => map.Ignore())
                .ForMember(o => o.Rate, map => map.MapFrom(o => o.Rate));

            CreateMap<OfferPropertyAdedViewModel, OfferPropertyAdedDto>()
    .ForMember(o => o.Comment, map => map.MapFrom(o => o.Comment))
    .ForMember(o => o.Rate, map => map.MapFrom(o => o.Rate));

            CreateMap<AnswerDto, Answer>()
                .ForMember(a => a.AnswerText, map => map.MapFrom(a => a.AnswerText))
                .ForMember(a => a.Question, map => map.MapFrom(a => a.Question));


            CreateMap<AnswerViewModel, AnswerDto>()
                .ForMember(a => a.AnswerText, map => map.MapFrom(a => a.AnswerText))
                .ForMember(a => a.Question, map => map.MapFrom(a => a.Question));

            CreateMap<QuestionViewModel, QuestionsDto>()
                .ForMember(q => q.QuestionText, map => map.MapFrom(qd => qd.QuestionText));

            CreateMap<QuestionsDto, Question>()
                .ForMember(q => q.QuestionText, map => map.MapFrom(q => q.QuestionText));

            CreateMap<Question, QuestionsDto>()
              .ForMember(q => q.QuestionText, map => map.MapFrom(q => q.QuestionText));

            CreateMap<QuestionsDto, QuestionViewModel>()
              .ForMember(q => q.QuestionText, map => map.MapFrom(q => q.QuestionText));

            CreateMap<AgentRegisterProfileViewModel, AgentProfile>()
                .ForMember(ap => ap.Age, map => map.MapFrom(a => a.Age))
                .ForMember(ap => ap.City, map => map.MapFrom(a => a.City))
                .ForMember(ap => ap.DefaultRate, map => map.MapFrom(a => a.DefaultRate))
                .ForMember(ap => ap.Description, map => map.MapFrom(a => a.Description));

            CreateMap<AgentRegisterViewModel, User>()
                .ForMember(u => u.FirstName, map => map.MapFrom(vm => vm.FirstName))
                .ForMember(u => u.LastName, map => map.MapFrom(vm => vm.LastName))
                .ForMember(u => u.Email, map => map.MapFrom(vm => vm.Email))
                .ForMember(u => u.PhoneNumber, map => map.MapFrom(vm => vm.PhoneNumber))
                .ForMember(u => u.ImagePath, map => map.Ignore())
                .ForMember(u => u.UserName, map => map.MapFrom(u => u.Email))
                .ForMember(u => u.AgentProfile, map => map.MapFrom(a => a.AgentProfile));


        }
    }
}

