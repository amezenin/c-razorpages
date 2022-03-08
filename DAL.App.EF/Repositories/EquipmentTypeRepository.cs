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
using EquipmentType = BLL.App.DTO.EquipmentType;

namespace DAL.App.EF.Repositories
{
    public class EquipmentTypeRepository : BaseRepository<DAL.App.DTO.EquipmentType, Domain.EquipmentType, AppDbContext>, IEquipmentTypeRepository
    {
        public EquipmentTypeRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new EquipmentTypeMapper())
        {
        }
        
        public override async Task<List<DAL.App.DTO.EquipmentType>> AllAsync()
        {
            return await RepositoryDbSet.Include(c => c.Equipments)
                .Select(e => EquipmentTypeMapper.MapFromDomain(e)).ToListAsync();
        }
        
       

        
        public virtual async Task<List<DAL.App.DTO.EquipmentTypeDTO>> GetAllWithEquipmentCountAsync()
        {
    
            return await RepositoryDbSet
                .Select(c => new EquipmentTypeDTO() 
                {
                    Id = c.Id,
                    Name = c.Name,
                    EquipmentsCount = c.Equipments.Count
                })
                .ToListAsync();
        }

        
        //dosnt need
        public Task<List<DAL.App.DTO.EquipmentType>> AllForUserAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<DAL.App.DTO.EquipmentType> FindForUserAsync(int id, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}