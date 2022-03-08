using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class Install
    {
        public BLL.App.DTO.Equipment Equipment { get; set; }
        public BLL.App.DTO.Farm Farm { get; set; }
        public BLL.App.DTO.Farmer Farmer { get; set; }
        public SelectList EquipmentTypeSelectList { get; set; }
        public SelectList FarmSelectList { get; set; }
    }
}