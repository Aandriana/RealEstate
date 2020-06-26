using RealEstate.BLL.DTO;
using RealEstate.BLL.DTO.UserDtos;
using RealEstateIdentity.ViewModels;
using System.Linq;
using RealEstate.BLL.Mapping;
using RealEstateIdentity.ViewModels.UserViewModels;

namespace RealEstateIdentity.Mapping
{
    public class MappingProfile : MappingProfileBll
    {
        public MappingProfile() : base()
        {
            CreateMap<LoginViewModel, LoginDto>();
            CreateMap<RegisterViewModel, RegisterDto>()
                .ForMember(u => u.ImagePath, map => map.Ignore());

            CreateMap<UserDetailsViewModel, UserDetailsDto>();
            CreateMap<UserDetailsDto, UserDetailsViewModel>();
            CreateMap<PropertyCreateViewModel, PropertyCreateDto>()
                .ForMember(p => p.AgentsId, opt => opt.MapFrom(vm => vm.AgentsId.AsQueryable()))
                .ForMember(p => p.QuestionsDtos, map => map.MapFrom(vm => vm.Questions.AsQueryable()));

            CreateMap<PropertyUpdateViewModel, PropertyUpdateDto>()
                .ForMember(p => p.QuestionsDtos, map => map.MapFrom(p => p.Questions.AsQueryable()));

            CreateMap<PropertyUpdatePhotosViewModel, PropertyUpdatePhotosDto>()
                .ForMember(p => p.NotDeletedContentImageUrls, map => map.MapFrom(vm => vm.NotDeletedContentImageUrls))
                .ForMember(p => p.AddedContentImages, map => map.MapFrom(vm => vm.AddedContentImages));

            CreateMap<PropertyListDto, PropertyListViewModel>();
            CreateMap<AnswerViewModel, AnswerDto>();
            CreateMap<QuestionViewModel, QuestionsDto>();
            CreateMap<QuestionsDto, QuestionViewModel>();
            CreateMap<AgentRegisterProfileViewModel, AgentRegisterProfileDto>();

            CreateMap<AgentRegisterViewModel, AgentRegisterDto>()
                .ForMember(u => u.ImagePath, map => map.Ignore());

            CreateMap<OfferFromUserViewModel, OfferFromUserDto>();

            CreateMap<OfferFromAgentViewModel, OfferFromAgentDto>();

            CreateMap<OfferResponseViewModel, OfferResponseDto>();

            CreateMap<QuestionUpdateViewModel, QuestionUpdateDto>()
                .ForMember(q => q.Question, map => map.MapFrom(q => q.Question.AsQueryable()));

            CreateMap<QuestionUpdateDto, QuestionUpdateViewModel>()
                .ForMember(q => q.Question, map => map.MapFrom(q => q.Question.AsQueryable()));

            CreateMap<AddQuestionViewModel, AddQuestionDto>()
                .ForMember(q => q.Questions, map => map.MapFrom(q => q.Questions.AsQueryable()));

            CreateMap<AddQuestionDto, AddQuestionViewModel>()
                .ForMember(q => q.Questions, map => map.MapFrom(q => q.Questions.AsQueryable()));

            CreateMap<AgentOfferResponseViewModel, AgentOfferResponseDto>()
                .ForMember(o => o.Answers, map => map.MapFrom(o => o.Answers.AsQueryable()));

            CreateMap<UsersListDto, UsersListViewModel>();
            CreateMap<AgentsListDto, AgentsListViewModel>();

            CreateMap<EditUserProfileViewModel, EditUserProfileDto>();
            CreateMap<EditAgentProfileViewModel, EditAgentProfileDto>();

            CreateMap<GetAgentByIdInfoDto, GetAgentByIdInfoViewModel>()
                .ForMember(a => a.FeedBacks, map => map.MapFrom(a => a.FeedBacks.AsQueryable()));

            CreateMap<FeedBackViewModel, FeedBackDto>();
            CreateMap<FeedBackDto, FeedBackViewModel>();

            CreateMap<FeedbackListDto, FeedBackListViewModel>();

        }
    }
}


