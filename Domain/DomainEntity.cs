using ee.itcollege.anmeze.Contracts.DAL.Base;

namespace Domain
{
    public abstract class DomainEntity : IDomainEntity
    {
        public int Id { get; set; }
    }
}