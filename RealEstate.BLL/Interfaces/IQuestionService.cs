using RealEstate.BLL.DTO;
using System.Threading.Tasks;

namespace RealEstate.BLL.Interfaces
{
    public interface IQuestionService
    {
        Task UpdateQuestion(int questionId, QuestionUpdateDto updateDto);
        Task DeleteQuestion(int questionId);
    }
}
