using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;

namespace BLL.App.DTO
{
    public class Farm
    {
        public int Id { get; set; }
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }

        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        //public ICollection<Tank> Tanks { get; set; }

        //public ICollection<Equipment> Equipments { get; set; }
    }
}