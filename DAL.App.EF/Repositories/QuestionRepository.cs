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
    public class QuestionRepository : BaseRepository<DAL.App.DTO.Question, Domain.Question, AppDbContext>, IQuestionRepository
    {
        
        
        public QuestionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new QuestionMapper())
        {
        }
        
        public override async Task<List<DAL.App.DTO.Question>> AllAsync()
        {
            return await RepositoryDbSet.Select(e => QuestionMapper.MapFromDomain(e)).ToListAsync();
        }


        public async Task<List<DAL.App.DTO.Question>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet.Select(e => QuestionMapper.MapFromDomain(e))
                .ToListAsync();

        }

        public async Task<DAL.App.DTO.Question> FindForUserAsync(int id, int userId)
        {
            return QuestionMapper.MapFromDomain(await RepositoryDbSet
                .FirstOrDefaultAsync(p => p.Id == id && p.Id == userId));
        }

        public Task<bool> BelongsToUserAsync(int id, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}