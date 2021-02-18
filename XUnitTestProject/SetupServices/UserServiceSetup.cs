using AutoMapper;
using Common.Configurations;
using Common.FilterClasses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Mocks;
using Moq;
using RealEstate.BLL.Interfaces;
using RealEstate.BLL.Services;
using RealEstate.DAL.Entities;
using RealEstate.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using XUnitTestProject.DefaultValues;
using XUnitTestProject.Services;

namespace XUnitTestProject.SetupServices
{
    public class UserServiceSetup
    {
        protected readonly Mock<IUnitOfWork> _unitOfWorkMock;
        protected readonly Mock<IFileService> _fileService;
        protected readonly UserService _userService;
        protected readonly RepositoryMock<User> _userRepoMock;
        protected readonly Mock<FakeUserManager> _userManagerMock;
        protected readonly Mock<FakeSigInManager> _signInManagerMock;
        protected readonly Mock<IAuthenticationService> _authService;
        protected readonly Mock<IMapper> _mapper;
        protected readonly Mock<IEmailService> _emailService;
        protected readonly Mock<IHostingEnvironment> _env;

        public UserServiceSetup()
        {
            _userRepoMock = new RepositoryMock<User>(GetUsersTestData().ToList());
            _userManagerMock = new Mock<FakeUserManager>();
            _signInManagerMock = new Mock<FakeSigInManager>();
            _authService = new Mock<IAuthenticationService>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _fileService = new Mock<IFileService>();
            _mapper = new Mock<IMapper>();
            _env = new Mock<IHostingEnvironment>();
            _emailService = new Mock<IEmailService>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            var _emailSettings = Options.Create(new EmailSettings());
            _unitOfWorkMock.Setup(u => u.Repository<User>()).Returns(_userRepoMock.Repository.Object);
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Verifiable();
            _unitOfWorkMock.Setup(u => u.Repository<User>()).Returns(_userRepoMock.Repository.Object);
            _userService = new UserService(_userManagerMock.Object, _signInManagerMock.Object, _authService.Object, _mapper.Object, _fileService.Object,
               _unitOfWorkMock.Object, _emailService.Object, _env.Object, _emailSettings);
        }
        protected IEnumerable<User> GetUsersTestData()
        {
            var data = new List<User>();
            var user = new User
            {
                Id = UserDefaultValues.DefaultId,
                Email = UserDefaultValues.DefaultEmail,
                UserName = UserDefaultValues.DefaultEmail.ToLower(),
                PasswordHash = UserDefaultValues.DefaultString,
                EmailConfirmed = true,
                ImagePath = UserDefaultValues.DefaultString

            };
            data.Add(user);
            return data.AsEnumerable();
        }

        protected PaginationParameters paginationParameters = new PaginationParameters();
    }
}
