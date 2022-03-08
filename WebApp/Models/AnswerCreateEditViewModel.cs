using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class AnswerCreateEditViewModel
    {
        public BLL.App.DTO.Answer Answer { get; set; }
        public SelectList QuestionSelectList { get; set; }
    }
}