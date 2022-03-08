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
    public class FarmerRepository : BaseRepository<DAL.App.DTO.Farmer, Domain.Farmer, AppDbContext>, IFarmerRepository
    {
        public FarmerRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new FarmerMapper())
        {
        }
        
        public async Task<List<DAL.App.DTO.Farmer>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet.Where(p => p.AppUserId == userId).Select(e => FarmerMapper.MapFromDomain(e))
                .ToListAsync();

        }

        public async Task<DAL.App.DTO.Farmer> FindForUserAsync(int id, int userId)
        {
            return FarmerMapper.MapFromDomain(await RepositoryDbSet.Include(p => p.AppUser)
                .FirstOrDefaultAsync(p => p.Id == id && p.AppUserId == userId));

        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet.AnyAsync(p => p.Id == id && p.AppUserId == userId);
        }
    }
}