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
    public class QuestionServiceSetup
    {
        protected readonly QuestionService _questionService;
        protected readonly Mock<IAuthenticationService> _authService;
        protected readonly Mock<IUnitOfWork> _unitOfWorkMock;
        protected readonly RepositoryMock<Question> _questionRepoMock;

        public QuestionServiceSetup()
        {
            _questionRepoMock = new RepositoryMock<Question>(GetQuestionTestData().ToList());
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _authService = new Mock<IAuthenticationService>();

            _questionService = new QuestionService(_unitOfWorkMock.Object, _authService.Object);
        }
        protected IEnumerable<Question> GetQuestionTestData()
        {
            var data = new List<Question>();
            var question = new Question
            {
                QuestionText = DefaultValues.DefaultValues.DefaultString,
                PropertyId = DefaultValues.DefaultValues.DefaultInt,
                Property = null
            };
            data.Add(question);
            return data.AsEnumerable();
        }
    }
}
