using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using ee.itcollege.anmeze.Contracts.DAL.Base;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using ee.itcollege.anmeze.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class FishTypeRepository : BaseRepository<DAL.App.DTO.FishType, Domain.FishType, AppDbContext>, IFishTypeRepository
    {
        public FishTypeRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new FishTypeMapper())
        {
        }
        
        // include Tank data in fishtype
        public override async Task<List<DAL.App.DTO.FishType>> AllAsync()
        {
            return await RepositoryDbSet.Include(c => c.Tanks)
                .Select(e => FishTypeMapper.MapFromDomain(e)).ToListAsync();
        }
        
        public virtual async Task<List<DAL.App.DTO.FishTypeDTO>> GetAllWithTankCountAsync()
        {
    
            return await RepositoryDbSet
                .Select(fishType => new FishTypeDTO()
                {
                    Id = fishType.Id,
                    Species = fishType.Species,
                    MaxTemp = fishType.MaxTemp,
                    MinTemp = fishType.MinTemp,
                    MaxNh = fishType.MaxNh,
                    MaxNo = fishType.MaxNo,
                    MaxDensity = fishType.MaxDensity,
                    TankCount = fishType.Tanks.Count
                })
                .ToListAsync();
        }

        public Task<List<DAL.App.DTO.FishType>> AllForUserAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<DAL.App.DTO.FishType> FindForUserAsync(int id, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}