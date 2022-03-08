using System.Collections;
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
    public class AnswerRepository : BaseRepository<DAL.App.DTO.Answer, Domain.Answer, AppDbContext>, IAnswerRepository
    {
        public AnswerRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new AnswerMapper())
        {
        }
        
        public override async Task<List<DAL.App.DTO.Answer>> AllAsync()
        {
            return await RepositoryDbSet.Include(c => c.Question)
                .Select(e => AnswerMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<List<DAL.App.DTO.Answer>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(c => c.Question)
                .Where(c => c.QuestionId == userId)
                .Select(e => AnswerMapper.MapFromDomain(e)).ToListAsync();

        }

        public async Task<DAL.App.DTO.Answer> FindForUserAsync(int id, int userId)
        {
            var contact = await RepositoryDbSet
                .Include(c => c.Question)
                
                .FirstOrDefaultAsync(m => m.Id == id && m.QuestionId == userId);

            return AnswerMapper.MapFromDomain(contact) ;

        }

        public Task<bool> BelongsToUserAsync(int id, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}