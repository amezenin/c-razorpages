using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class PersonQuestionVastaViewModel
    {
        public BLL.App.DTO.PersonQuestion PersonQuestion { get; set; }
        public BLL.App.DTO.Solution Solution { get; set; }
        public BLL.App.DTO.Farmer Farmer { get; set; }
        public BLL.App.DTO.Answer Answer { get; set; }
        public BLL.App.DTO.Question Question { get; set; }
        public BLL.App.DTO.AnsweredQuestion AnsweredQuestion { get; set; }
        
       // public SelectList FarmerSelectList { get; set; }
       // public SelectList QuestionSelectList { get; set; }
    }
}