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
    public class FarmRepository : BaseRepository<DAL.App.DTO.Farm, Domain.Farm, AppDbContext>, IFarmRepository
    {
        public FarmRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new FarmMapper())
        {
        }


        public async Task<List<DAL.App.DTO.Farm>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                //.Include(c => c.Tanks)
                .Include(c => c.Farmer)
                //.Include(c => c.Equipments)
                .Where(c => c.Farmer.AppUserId == userId)
                .Select(e => FarmMapper.MapFromDomain(e)).ToListAsync();

        }

        public async Task<DAL.App.DTO.Farm> FindForUserAsync(int id, int userId)
        {
            var farm = await RepositoryDbSet
                //.Include(c => c.Tanks)
                .Include(c => c.Farmer)
                //.Include(c => c.Equipments)
                .FirstOrDefaultAsync(m => m.Id == id && m.Farmer.AppUserId == userId);

            return FarmMapper.MapFromDomain(farm) ;

        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet
                .AnyAsync(c => c.Id == id && c.Farmer.AppUserId == userId);

        }
    }
}