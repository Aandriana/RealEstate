using Common.Exceptions;
using RealEstate.BLL.DTO;
using RealEstate.BLL.Interfaces;
using RealEstate.DAL.Entities;
using RealEstate.DAL.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace RealEstate.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _authenticationService;
        public QuestionService(IUnitOfWork unitOfWork, IAuthenticationService authentication)
        {
            _unitOfWork = unitOfWork;
            _authenticationService = authentication;
        }

        public async Task UpdateQuestion(int questionId, QuestionUpdateDto updateDto)
        {
            var user = await _authenticationService.GetCurrentUserAsync();

            var question = await _unitOfWork.Repository<Question>().GetAsync(q => q.Id == questionId) ?? throw new NotFoundException("Question");

            if (question.CreatedById != user.Id) throw new NoPermissionsException("You don't have permission for updating this question as you dont't own");

            question.QuestionText = updateDto.Question;

            await _unitOfWork.Repository<Question>().UpdateAsync(question);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteQuestion(int questionId)
        {
            var user = await _authenticationService.GetCurrentUserAsync();
            var question = await _unitOfWork.Repository<Question>().GetAsync(q => q.Id == questionId) ?? throw new NotFoundException("Question");
            if (question.CreatedById != user.Id) throw new NoPermissionsException("You don't have permission for removing this question as you dont't own");

            _unitOfWork.Repository<Question>().Remove(question);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
