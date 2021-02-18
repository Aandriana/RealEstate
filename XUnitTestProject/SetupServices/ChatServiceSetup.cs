using AutoMapper;
using Moq;
using RealEstate.BLL.Interfaces;
using RealEstate.BLL.Services;
using RealEstate.DAL.Entities;
using RealEstate.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using XUnitTestProject.Services;

namespace XUnitTestProject.SetupServices
{
    public class ChatServiceSetup
    {
        protected readonly Mock<IUnitOfWork> _unitOfWorkMock;
        protected readonly RepositoryMock<Chat> _chatRepoMock;
        protected readonly Mock<IAuthenticationService> _authService;
        protected readonly ChatService _chatService;
        protected readonly Mock<IMapper> _mapper;

        public ChatServiceSetup()
        {
            _chatRepoMock = new RepositoryMock<Chat>(GetUsersTestData().ToList());
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _authService = new Mock<IAuthenticationService>();
            _chatService = new ChatService(_authService.Object, _mapper.Object, _unitOfWorkMock.Object);
        }

        protected IEnumerable<Chat> GetUsersTestData()
        {
            var data = new List<Chat>();
            var chat = new Chat
            {
                Name = DefaultValues.DefaultValues.DefaultString,
                Messages = null,
                Participants = null
            };
            data.Add(chat);
            return data.AsEnumerable();
        }
    }
}
