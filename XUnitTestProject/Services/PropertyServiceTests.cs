using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitTestProject.SetupServices;

namespace XUnitTestProject.Services
{
    public class PropertyServiceTests: QuestionServiceSetup
    {
        public PropertyServiceTests(): base()
        {

        }
        //[Fact]
        //public async Task AddProperty_ShoulCallSaveChanges()
        //{
        //    Func<Task> result = async () => await _propertyService.AddProperty(DefaultValues.DefaultValues.propertyCreate);
        //    _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.AtLeastOnce);
        //}
        [Fact]
        public async Task DeleteQuestion_ShoulBeExeption()
        {
            Func<Task> result = async () => await _questionService.DeleteQuestion(DefaultValues.DefaultValues.DefaultInt);
            await result.Should().ThrowAsync<NullReferenceException>();
        }
        [Fact]
        public async Task UpdateQuestion_ShoulBeExeption()
        {
            Func<Task> result = async () => await _questionService.UpdateQuestion(DefaultValues.DefaultValues.DefaultInt, null);
            await result.Should().ThrowAsync<NullReferenceException>();
        }
        [Fact]
        public async Task DeleteQuestiosn_ShoulBeExeption()
        {
            Func<Task> result = async () => await _questionService.DeleteQuestion(DefaultValues.DefaultValues.DefaultInt);
            await result.Should().ThrowAsync<NullReferenceException>();
        }
        [Fact]
        public async Task UpdateQuestiosn_ShoulBeExeption()
        {
            Func<Task> result = async () => await _questionService.UpdateQuestion(DefaultValues.DefaultValues.DefaultInt, null);
            await result.Should().ThrowAsync<NullReferenceException>();
        }
        [Fact]
        public async Task DeleteQuestiosn_ShoulBeExeptions()
        {
            Func<Task> result = async () => await _questionService.DeleteQuestion(DefaultValues.DefaultValues.DefaultInt);
            await result.Should().ThrowAsync<NullReferenceException>();
        }
        [Fact]
        public async Task UpdateQuestiosn_ShoulBeExeptions()
        {
            Func<Task> result = async () => await _questionService.UpdateQuestion(DefaultValues.DefaultValues.DefaultInt, null);
            await result.Should().ThrowAsync<NullReferenceException>();
        }
        [Fact]
        public async Task DeleteQuesstiosn_ShoulBeExeptions()
        {
            Func<Task> result = async () => await _questionService.DeleteQuestion(DefaultValues.DefaultValues.DefaultInt);
            await result.Should().ThrowAsync<NullReferenceException>();
        }
        [Fact]
        public async Task UpdateQuestisosn_ShoulBeExeptions()
        {
            Func<Task> result = async () => await _questionService.UpdateQuestion(DefaultValues.DefaultValues.DefaultInt, null);
            await result.Should().ThrowAsync<NullReferenceException>();
        }
        [Fact]
        public async Task DeleteQuestidosn_ShoulBeExeptions()
        {
            Func<Task> result = async () => await _questionService.DeleteQuestion(DefaultValues.DefaultValues.DefaultInt);
            await result.Should().ThrowAsync<NullReferenceException>();
        }
        [Fact]
        public async Task UpdateQuedstiosn_ShoulBeExeptions()
        {
            Func<Task> result = async () => await _questionService.UpdateQuestion(DefaultValues.DefaultValues.DefaultInt, null);
            await result.Should().ThrowAsync<NullReferenceException>();
        }
        [Fact]
        public async Task DeleteQuwestiosn_ShoulBeExeptions()
        {
            Func<Task> result = async () => await _questionService.DeleteQuestion(DefaultValues.DefaultValues.DefaultInt);
            await result.Should().ThrowAsync<NullReferenceException>();
        }
        [Fact]
        public async Task UpdateQuestiwosn_ShoulBeExeptions()
        {
            Func<Task> result = async () => await _questionService.UpdateQuestion(DefaultValues.DefaultValues.DefaultInt, null);
            await result.Should().ThrowAsync<NullReferenceException>();
        }
    }
}
