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
    public class AnsweredQuestionRepository : BaseRepository<DAL.App.DTO.AnsweredQuestion, Domain.AnsweredQuestion, AppDbContext>, IAnsweredQuestionsRepository
    {
        public AnsweredQuestionRepository(AppDbContext  repositoryDbContext) : base(repositoryDbContext, new AnsweredQuestionMapper())
        {
        }
        
        public async Task<List<DAL.App.DTO.AnsweredQuestion>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(c => c.Question)
                .Include(c => c.Farmer)            
                .Where(c => c.Farmer.AppUserId == userId)
                .Select(e => AnsweredQuestionMapper.MapFromDomain(e)).ToListAsync();
            
            
        }

        public async Task<DAL.App.DTO.AnsweredQuestion> FindForUserAsync(int id, int userId)
        {
            var answeredQuestion = await RepositoryDbSet
                .Include(c => c.Question)
                .Include(c => c.Farmer)
                .FirstOrDefaultAsync(m => m.Id == id && m.Farmer.AppUserId == userId);

            return AnsweredQuestionMapper.MapFromDomain(answeredQuestion) ;

        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet.AnyAsync(c => c.Id == id && c.Farmer.AppUserId == userId);
        }

        
    }
}