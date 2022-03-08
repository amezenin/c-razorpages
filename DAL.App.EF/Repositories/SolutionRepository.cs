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
    public class SolutionRepository : BaseRepository<DAL.App.DTO.Solution, Domain.Solution, AppDbContext>, ISolutionRepository
    {
        public SolutionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new SolutionMapper())
        {
        }
        
        public override async Task<List<DAL.App.DTO.Solution>> AllAsync()
        {
            return await RepositoryDbSet.Include(c => c.Question)
                .Select(e => SolutionMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<List<DAL.App.DTO.Solution>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(c => c.Question)
                .Where(c => c.QuestionId == userId)
                .Select(e => SolutionMapper.MapFromDomain(e)).ToListAsync();

        }

        public async Task<DAL.App.DTO.Solution> FindForUserAsync(int id, int userId)
        {
            var contact = await RepositoryDbSet
                .Include(c => c.Question)
                
                .FirstOrDefaultAsync(m => m.Id == id && m.QuestionId == userId);

            return SolutionMapper.MapFromDomain(contact) ;
        }


        public Task<bool> BelongsToUserAsync(int id, int userId)
        {
            throw new System.NotImplementedException();
        }

       
    }
}