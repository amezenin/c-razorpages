using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public int QuestionGivesScore { get; set; }
        public int QuestionMinScore { get; set; }
        public int QuestionMaxScore { get; set; }

       
        //public Answer Answer { get; set; }

        
       // public Solution Solution { get; set; }

        public ICollection<AnsweredQuestion> AnsweredQuestions { get; set; }
         public ICollection<PersonQuestion> PersonQuestions { get; set; }
    }
}