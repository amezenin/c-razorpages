using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class FarmCreateEditViewModel
    {
        public BLL.App.DTO.Farm Farm { get; set; }
        public SelectList FarmerSelectList { get; set; }
        

    }
}