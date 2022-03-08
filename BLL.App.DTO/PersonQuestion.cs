namespace BLL.App.DTO
{
    public class PersonQuestion
    {
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}