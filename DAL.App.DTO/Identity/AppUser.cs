using System.Collections.Generic;

namespace DAL.App.DTO.Identity
{
    public class AppUser
    {
        public int Id { get; set; }
        public ICollection<Farmer> Farmers { get; set; }

    }
}