using AutoMapper;
using RealEstate.BLL.DTO;
using RealEstate.BLL.DTO.UserDtos;
using RealEstate.DAL.Entities;
using System.Linq;

namespace RealEstate.BLL.Mapping
{
    public class MappingProfileBll : Profile
    {
        public MappingProfileBll()
        {
            CreateMap<RegisterDto, User>()
                .ForMember(u => u.ImagePath, map => map.Ignore())
                .ForMember(u => u.UserName, mqp => mqp.MapFrom(vm => vm.Email));

            CreateMap<UserDetailsDto, User>()
                     .ForMember(u => u.UserName, mqp => mqp.MapFrom(vm => vm.Email));

            CreateMap<User, UserDetailsDto>();

            CreateMap<AgentRegisterProfileDto, AgentProfile>();

            CreateMap<AgentRegisterDto, User>()
                .ForMember(u => u.ImagePath, map => map.Ignore())
                .ForMember(u => u.UserName, map => map.MapFrom(u => u.Email));

            CreateMap<PropertyCreateDto, Property>()
                .ForMember(p => p.Offers, map => map.Ignore())
                .ForMember(p => p.Photos, map => map.Ignore())
                .ForMember(p => p.Questions, map => map.Ignore());

            CreateMap<Property, PropertyCreateDto>()
                .ForMember(p => p.Photos, map => map.Ignore())
                .ForMember(p => p.QuestionsDtos, map => map.MapFrom(p => p.Questions.AsQueryable())); ;

            CreateMap<Property, GetPropertyDto>()
                .ForMember(p => p.OfferDtos, map => map.MapFrom(p => p.Offers.AsQueryable()))
                .ForMember(p => p.PhotosDtos, opt => opt.MapFrom(vm => vm.Photos.Select(p => p.Path)))
                .ForMember(p => p.QuestionsDtos, map => map.MapFrom(p => p.Questions.AsQueryable()));

            CreateMap<Offer, OfferDto>()
                .ForMember(o => o.Status, map => map.Ignore());

            CreateMap<Property, PropertyListDto>();

            CreateMap<Answer, AnswerDto>();
            CreateMap<AnswerDto, Answer>();

            CreateMap<QuestionsDto, Question>();
            CreateMap<Question, QuestionsDto>();

            CreateMap<QuestionUpdateDto, Question>()
                .ForMember(q => q.QuestionText, map => map.MapFrom(q => q.Question));
            CreateMap<Question, QuestionUpdateDto>()
                .ForMember(q => q.Question, map => map.MapFrom(q => q.QuestionText));

            CreateMap<OfferFromUserDto, Offer>()
         .ForMember(o => o.Status, map => map.Ignore());

            CreateMap<OfferFromAgentDto, Offer>()
                .ForMember(o => o.Status, map => map.Ignore());

            CreateMap<Offer, OfferDto>();

            CreateMap<User, UsersListDto>();
            CreateMap<AgentProfile, AgentsListDto>();

            CreateMap<EditAgentProfileDto, AgentRegisterDto>();
            CreateMap<EditUserProfileDto, User>();

            CreateMap<AgentProfile, GetAgentByIdInfoDto>();

            CreateMap<FeedBackDto, Feedback>();
            CreateMap<Feedback, FeedBackDto>();

            CreateMap<Feedback, FeedbackListDto>();

        }
    }
}
