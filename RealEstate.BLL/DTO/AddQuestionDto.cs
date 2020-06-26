using System.Collections.Generic;

namespace RealEstate.BLL.DTO
{
    public class AddQuestionDto
    {
        public ICollection<QuestionUpdateDto> Questions { get; set; }
    }
}
