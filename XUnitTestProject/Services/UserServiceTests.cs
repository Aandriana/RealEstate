using Common.FilterClasses;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitTestProject.DefaultValues;

namespace XUnitTestProject.Services
{
    public class UserServiceTests : SetupServices.UserServiceSetup
    {
        public UserServiceTests() : base()
        {

        }

        [Fact]
        public async Task GetMyProfile_Exception()
        {
            Func<Task> result = async () => await _userService.GetMyInfo();
            await result.Should().ThrowAsync<UnauthorizedAccessException>();
        }

        [Fact]
        public async Task GetCurrentAgent_Exception()
        {
            Func<Task> result = async () => await _userService.GetCurrentAgent();
            await result.Should().ThrowAsync<NullReferenceException>();
        }

        [Fact]
        public async Task GetUserRole_ShouldReturnNull()
        {
            Func<Task> result = async () =>  await _userService.GetAllAgents(paginationParameters);
            await result.Should().ThrowAsync<Common.Exceptions.NotFoundException>();
        }

        [Fact]
        public async Task GetCurrentAgentFeedbacks_ShouldReturnException()
        {
            Func<Task> result = async () => await _userService.GetCurrentAgentFeedbacks();
            await result.Should().ThrowAsync<NullReferenceException>();
        }

        [Fact]
        public async Task GetAgentById_ShouldReturnException()
        {
            Func<Task> result = async () => await _userService.GetAgentById(DefaultValues.UserDefaultValues.FakeId);
            await result.Should().ThrowAsync<NullReferenceException>();
        }
        [Fact]
        public async Task GetCurrentAgentFeedbacks_ShoulBeExeption()
        {
            Func<Task> result = async () => await _userService.GetCurrentAgentFeedbacks();
            await result.Should().ThrowAsync<NullReferenceException>();
        }
    }
}
