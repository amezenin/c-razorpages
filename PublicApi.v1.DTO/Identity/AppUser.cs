using System.Collections.Generic;

namespace PublicApi.v1.DTO.Identity
{
    public class AppUser
    {
        public int Id { get; set; }
        public ICollection<Farmer> Farmers { get; set; }
    }
}