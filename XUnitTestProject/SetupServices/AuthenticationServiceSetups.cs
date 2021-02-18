using Common.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Mocks;
using Moq;
using RealEstate.BLL.Services;
using RealEstate.DAL.Entities;
using RealEstate.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using XUnitTestProject.DefaultValues;

namespace XUnitTestProject.Services
{
    public class AuthenticationServiceSetups
    {
        protected readonly AuthenticationService _authService;
        protected readonly Mock<IUnitOfWork> _unitOfWorkMock;
        protected readonly RepositoryMock<User> _userRepoMock;
        protected readonly Mock<FakeUserManager> _userManagerMock;
        protected readonly Mock<FakeSigInManager> _signInManagerMock;
        public AuthenticationServiceSetups()
        {
            _userRepoMock = new RepositoryMock<User>(GetUsersTestData().ToList());
            _userManagerMock = new Mock<FakeUserManager>();
            _signInManagerMock = new Mock<FakeSigInManager>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _unitOfWorkMock.Setup(u => u.Repository<User>()).Returns(_userRepoMock.Repository.Object);
            var _tokenSettings = Options.Create(new TokenManagement());
            _tokenSettings.Value.JwtKey = "Any String used to sign and verify JWT Tokens,  Replace this string with your own Secret";
            _tokenSettings.Value.JwtIssuer = "Some secret";
            _tokenSettings.Value.JwtExpireDays = 3600;
            var _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            var claims = new List<Claim>();
            claims.Add(new Claim("Id", UserDefaultValues.DefaultId));
            claims.Add(new Claim(ClaimTypes.Email, UserDefaultValues.DefaultEmail));
            claims.Add(new Claim(ClaimTypes.Role, UserDefaultValues.DefaultRoleId));
            _mockHttpContextAccessor.Setup(u => u.HttpContext.User.Claims).Returns(claims.AsEnumerable);
           // _signInManagerMock.Setup(s => s.CreateUserPrincipalAsync(It.IsAny<User>())).ReturnsAsync(claims).Verifiable());
            _authService = new AuthenticationService(_tokenSettings, _signInManagerMock.Object, _userManagerMock.Object, _mockHttpContextAccessor.Object);
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
    }
}
