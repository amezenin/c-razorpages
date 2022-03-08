using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebApp.Models
{
    public class SolutionCreateEditViewModel
    {
        public BLL.App.DTO.Solution Solution { get; set; }
        public SelectList QuestionSelectList { get; set; }
    }
}