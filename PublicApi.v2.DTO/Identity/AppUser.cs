using System.Collections.Generic;

namespace PublicApi.v2.DTO.Identity
{
    public class AppUser
    {
        public int Id { get; set; }
        public ICollection<Farmer> Farmers { get; set; }
    }
}