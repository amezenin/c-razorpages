using System.Linq;
using ee.itcollege.anmeze.Contracts.DAL.Base;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    //Force identity DBConext use our appuser and approle with int as PK type
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnsweredQuestion> AnsweredQuestions { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<FishType> FishTypes { get; set; }
        public DbSet<PersonQuestion> PersonQuestions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        
        
        
        // todo cascade delete

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // disable cascade delete
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

                    
        
    }
}