using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class TankFeedViewModel
    {
        public BLL.App.DTO.Tank Tank { get; set; }
        public BLL.App.DTO.Farmer Farmer { get; set; }
        public BLL.App.DTO.TankDTO TankDTO { get; set; }
        public SelectList FarmSelectList { get; set; }
        public SelectList FishTypeSelectList { get; set; }
    }
}