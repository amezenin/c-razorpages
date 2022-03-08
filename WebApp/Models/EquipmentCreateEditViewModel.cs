using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class EquipmentCreateEditViewModel
    {
        public BLL.App.DTO.Equipment Equipment { get; set; }
        public SelectList EquipmentTypeSelectList { get; set; }
        public SelectList FarmSelectList { get; set; }
    }
}