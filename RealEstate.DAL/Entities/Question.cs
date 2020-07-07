namespace RealEstate.DAL.Entities
{
    public class Question : BaseEntity
    {
        public string QuestionText { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
