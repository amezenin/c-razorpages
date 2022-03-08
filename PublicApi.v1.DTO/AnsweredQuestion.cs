namespace PublicApi.v1.DTO
{
    public class AnsweredQuestion
    {
        public int Id { get; set; }
        public bool Value { get; set; }

        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}