using System.Collections.Generic;

namespace RealEstate.BLL.DTO
{
    public class QuestionsUpdateDto
    {
        public virtual ICollection<QuestionsDto> Questions { get; set; }
    }
}
