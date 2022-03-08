using System.Collections.Generic;
using BLL.App.DTO;

namespace DAL.App.DTO.Identity
{
    public class AppUser
    {
        public int Id { get; set; }
        public ICollection<Farmer> Farmers { get; set; }

    }
}