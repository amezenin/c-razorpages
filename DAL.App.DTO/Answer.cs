using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO
{
    public class Answer
    {
        public int Id { get; set; }
        [Required]
        public string AnswerValueFirst { get; set; }
        [Required]
        public string AnswerValueSecond { get; set; }
        [Required]
        public string AnswerValueThird { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}