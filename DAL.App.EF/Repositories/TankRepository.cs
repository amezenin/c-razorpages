using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.DAL.App.Repositories;
using ee.itcollege.anmeze.Contracts.DAL.Base;
using DAL.App.EF.Mappers;
using ee.itcollege.anmeze.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using TankDTO = DAL.App.DTO.TankDTO;

namespace DAL.App.EF.Repositories
{
    public class TankRepository : BaseRepository<DAL.App.DTO.Tank, Domain.Tank, AppDbContext>, ITankRepository
    {
        public TankRepository(AppDbContext  repositoryDbContext) : base(repositoryDbContext, new TankMapper())
        {
        }
        
        public virtual async Task<List<TankDTO>> GetAllWithBiomassAsync(int userId)
        {

            return await RepositoryDbSet
                .Include(c => c.Farm)
                .Include(c => c.Farm.Farmer)
                .Where(c => c.Farm.Farmer.AppUserId == userId)
                .Select(tank => new TankDTO()
                {
                    Id = tank.Id,
                    Name = tank.Name,
                    Dimension = tank.Dimension,
                    Quantity = tank.Quantity,
                    AverageMass = tank.AverageMass,
                    RealFcr = tank.RealFcr,
                    RealNh = tank.RealNh,
                    RealNo = tank.RealNo,
                    FarmId = tank.FarmId,
                    Farm = FarmMapper.MapFromDomain(tank.Farm),
                    FishTypeId = tank.FishTypeId,
                    FishType = FishTypeMapper.MapFromDomain(tank.FishType),
                    
                    //Other place where I can calculate DTO data: BLL.App/Mappers/TankMapper. Now its here!
                    
                    /*Biomass =  tank.AverageMass * Convert.ToSingle(tank.Quantity),
                    FeedPercent = Convert.ToSingle(tank.RealFcr) / 100,
                    FeedKg = tank.AverageMass * Convert.ToSingle(tank.Quantity) * Convert.ToSingle(tank.RealFcr) / 100 ,
                    GrowingDay = tank.AverageMass * Convert.ToSingle(tank.Quantity) * Convert.ToSingle(tank.RealFcr) / 100 / tank.RealFcr,
                    NewBiomass = (tank.AverageMass * Convert.ToSingle(tank.Quantity)) + 
                                          (tank.AverageMass * Convert.ToSingle(tank.Quantity) * Convert.ToSingle(tank.RealFcr) / 100 / tank.RealFcr) ,
                    NewAverage = ((tank.AverageMass * Convert.ToSingle(tank.Quantity)) + 
                                 (tank.AverageMass * Convert.ToSingle(tank.Quantity) * Convert.ToSingle(tank.RealFcr) / 100 / tank.RealFcr)) / Convert.ToSingle(tank.Quantity),
                    Density = tank.AverageMass * Convert.ToSingle(tank.Quantity) / Convert.ToSingle(tank.Dimension)*/
                    
                })
                .ToListAsync();
        }

        public async Task<TankDTO> GetTankWithBiomassAsync(int id, int userId)
        {
            
            return await RepositoryDbSet
                    .Select(tank => new TankDTO()
                    {
                        Id = tank.Id,
                        Name = tank.Name,
                        Dimension = tank.Dimension,
                        Quantity = tank.Quantity,
                        AverageMass = tank.AverageMass,
                        RealFcr = tank.RealFcr,
                        RealNh = tank.RealNh,
                        RealNo = tank.RealNo,
                        FarmId = tank.FarmId,
                        Farm = FarmMapper.MapFromDomain(tank.Farm),
                        FishTypeId = tank.FishTypeId,
                        FishType = FishTypeMapper.MapFromDomain(tank.FishType),
                    
                    
                    })
                    .FirstOrDefaultAsync(m => m.Id == id );
        }


        public async Task<List<DAL.App.DTO.Tank>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(c => c.FishType)
                .Include(c => c.Farm)
                //.Include(c => c.Equipments)
                .Where(c => c.Farm.Farmer.AppUserId == userId)
                .Select(e => TankMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<DAL.App.DTO.Tank> FindForUserAsync(int id, int userId)
        {
            var tank = await RepositoryDbSet
                .Include(c => c.FishType)
                .Include(c => c.Farm)
                //.Include(c => c.Equipments)
                .FirstOrDefaultAsync(m => m.Id == id && m.Farm.Farmer.AppUserId == userId);

            return TankMapper.MapFromDomain(tank) ;
        }
        
       
        
        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet
                .AnyAsync(c => c.Id == id && c.Farm.Farmer.AppUserId == userId);

        }
    }
}