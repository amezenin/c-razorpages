using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class TankCreateEditViewModel
    {
        public BLL.App.DTO.Tank Tank { get; set; }
        public SelectList FarmSelectList { get; set; }
        public SelectList FishTypeSelectList { get; set; }

    }
}