using System;
using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class AnsweredQuestionCreateEditViewModel
    {
        public BLL.App.DTO.AnsweredQuestion AnsweredQuestion { get; set; }
        public Boolean Value { get; set; }
        public SelectList FarmerSelectList { get; set; }
        public SelectList QuestionSelectList { get; set; }
    }
}