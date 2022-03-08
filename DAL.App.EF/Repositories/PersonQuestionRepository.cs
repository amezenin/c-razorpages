using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using ee.itcollege.anmeze.Contracts.DAL.Base;
using DAL.App.EF.Mappers;
using ee.itcollege.anmeze.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PersonQuestionRepository : BaseRepository<DAL.App.DTO.PersonQuestion, Domain.PersonQuestion, AppDbContext>, IPersonQuestionRepository
    {
        public PersonQuestionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new PersonQuestionMapper())
        {
        }

        public async Task<List<DAL.App.DTO.PersonQuestion>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(c => c.Question)
                .Include(c => c.Farmer)            
                .Where(c => c.Farmer.AppUserId == userId)
                .Select(e => PersonQuestionMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<DAL.App.DTO.PersonQuestion> FindForUserAsync(int id, int userId)
        {
            var personQuestion = await RepositoryDbSet
                .Include(c => c.Question)
                .Include(c => c.Farmer)
                .FirstOrDefaultAsync(m => m.Id == id && m.Farmer.AppUserId == userId);

            return PersonQuestionMapper.MapFromDomain(personQuestion) ;
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet.AnyAsync(c => c.Id == id && c.Farmer.AppUserId == userId); 
        }

        
    }
}