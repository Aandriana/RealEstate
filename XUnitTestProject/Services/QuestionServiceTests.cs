using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitTestProject.SetupServices;

namespace XUnitTestProject.DefaultValues
{
    public class QuestionServiceTests: QuestionServiceSetup
    {
        public QuestionServiceTests(): base()
        {

        }
        [Fact]
        public async Task DeleteQuestion_ShoulBeExeption()
        {
            Func<Task> result = async () => await _questionService.DeleteQuestion(DefaultValues.DefaultInt);
            await result.Should().ThrowAsync<NullReferenceException>();
        }
        [Fact]
        public async Task UpdateQuestion_ShoulBeExeption()
        {
            Func<Task> result = async () => await _questionService.UpdateQuestion(DefaultValues.DefaultInt, null);
            await result.Should().ThrowAsync<NullReferenceException>();
        }
    }
}
