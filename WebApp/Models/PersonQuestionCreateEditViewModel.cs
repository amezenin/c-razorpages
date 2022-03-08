using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class PersonQuestionCreateEditViewModel
    {
        public BLL.App.DTO.PersonQuestion PersonQuestion { get; set; }
        public SelectList FarmerSelectList { get; set; }
        public SelectList QuestionSelectList { get; set; }
    }
}