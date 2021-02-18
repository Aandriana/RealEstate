using FluentAssertions;
using RealEstate.DAL.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using XUnitTestProject.DefaultValues;

namespace XUnitTestProject.Services
{
    public class AuthenticationServiceTests: AuthenticationServiceSetups
    {
        public AuthenticationServiceTests() : base()
        {
        }
        [Fact]
        public async Task Authenticate_Exception()
        {
            var user = new User();
            Func<Task> result = async () => await _authService.GenerateJwtToken(user);
            await result.Should().ThrowAsync<NullReferenceException>();
        }
        [Fact]
        public async Task GetCurrentUser_ShouldReturnNull()
        {
            var result = await _authService.GetCurrentUserAsync();
            result.Should().BeNull();
        }
        [Fact]
        public async Task GetUserRole_ShouldReturnNull()
        {
            var user = GetUsersTestData().Where(u => u.Id == UserDefaultValues.FakeId).FirstOrDefault();
            var result = await _authService.GetCurrentUserRolesAsync(user);
            result.Should().BeNull();
        }
    }
}
