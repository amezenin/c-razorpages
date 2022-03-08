

using System.Collections.Generic;
using ee.itcollege.anmeze.Contracts.DAL.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUser : IdentityUser<int>, IDomainEntity
    {
        public ICollection<Farmer> Farmers { get; set; }
    }
}