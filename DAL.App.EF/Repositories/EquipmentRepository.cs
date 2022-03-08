using System;
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
using Equipment = BLL.App.DTO.Equipment;

namespace DAL.App.EF.Repositories
{
    public class EquipmentRepository : BaseRepository<DAL.App.DTO.Equipment, Domain.Equipment, AppDbContext>, IEquipmentRepository
    {
        public EquipmentRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new EquipmentMapper())
        {
        }

        public async Task<List<DAL.App.DTO.Equipment>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(c => c.Farm)
                .Include(c => c.EquipmentType)
                .Where(c => c.Farm.Farmer.AppUserId == userId)
                .Select(e => EquipmentMapper.MapFromDomain(e)).ToListAsync();

        }

        public async Task<DAL.App.DTO.Equipment> FindForUserAsync(int id, int userId)
        {
            var equipment = await RepositoryDbSet
                .Include(c => c.Farm)
                .Include(c => c.EquipmentType)
                //.Include(c => c.Equipments)
                .FirstOrDefaultAsync(m => m.Id == id && m.Farm.Farmer.AppUserId == userId);

            return EquipmentMapper.MapFromDomain(equipment) ;
        }
        
        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet.AnyAsync(c => c.Id == id && c.Farm.Farmer.AppUserId == userId);
        }
    }
}