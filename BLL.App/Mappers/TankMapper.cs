using System;
using ee.itcollege.anmeze.Contract.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class TankMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Tank))
            {
                return MapFromDAL((internalDTO.Tank) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Tank))
            {
                return MapFromBLL((externalDTO.Tank) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Tank MapFromDAL(internalDTO.Tank tank)
        {
            var res = tank == null ? null : new externalDTO.Tank
            {
                Id = tank.Id,
                FarmId = tank.FarmId,
                Farm = FarmMapper.MapFromDAL(tank.Farm),
                FishTypeId = tank.FishTypeId,
                FishType = FishTypeMapper.MapFromDAL(tank.FishType),
                Name = tank.Name,
                Dimension = tank.Dimension,
                Quantity = tank.Quantity,
                AverageMass = tank.AverageMass,
                RealFcr = tank.RealFcr,
                RealNh = tank.RealNh,
                RealNo = tank.RealNo
                
            };

            return res;
        }

        public static internalDTO.Tank MapFromBLL(externalDTO.Tank tank)
        {
            var res = tank == null ? null : new internalDTO.Tank
            {
                Id = tank.Id,
                FarmId = tank.FarmId,
                Farm = FarmMapper.MapFromBLL(tank.Farm),
                FishTypeId = tank.FishTypeId,
                FishType = FishTypeMapper.MapFromBLL(tank.FishType),
                Name = tank.Name,
                Dimension = tank.Dimension,
                Quantity = tank.Quantity,
                AverageMass = tank.AverageMass,
                RealFcr = tank.RealFcr,
                RealNh = tank.RealNh,
                RealNo = tank.RealNo
               
            };
            return res;
        }
        
        public static externalDTO.TankDTO MapFromDAL(internalDTO.TankDTO tankDTO)
        {
            var res = tankDTO == null ? null : new externalDTO.TankDTO()
            {
                Id = tankDTO.Id,
                FarmId = tankDTO.FarmId,
                Farm = FarmMapper.MapFromDAL(tankDTO.Farm),
                FishTypeId = tankDTO.FishTypeId,
                FishType = FishTypeMapper.MapFromDAL(tankDTO.FishType),
                Name = tankDTO.Name,
                Dimension = tankDTO.Dimension,
                Quantity = tankDTO.Quantity,
                AverageMass = tankDTO.AverageMass,
                RealFcr = tankDTO.RealFcr,
                RealNh = tankDTO.RealNh,
                RealNo = tankDTO.RealNo,
                Biomass = Math.Round(tankDTO.Quantity * tankDTO.AverageMass, 2),
                FeedPercent = Math.Round(Convert.ToSingle(tankDTO.RealFcr) / 100, 3),
                FeedKg = Math.Round(tankDTO.AverageMass * Convert.ToSingle(tankDTO.Quantity) * Convert.ToSingle(tankDTO.RealFcr) / 100, 2),
                GrowingDay = Math.Round(tankDTO.AverageMass * Convert.ToSingle(tankDTO.Quantity) * Convert.ToSingle(tankDTO.RealFcr) / 100 / tankDTO.RealFcr, 2),
                NewBiomass = Math.Round((tankDTO.AverageMass * Convert.ToSingle(tankDTO.Quantity)) + 
                             (tankDTO.AverageMass * Convert.ToSingle(tankDTO.Quantity) * Convert.ToSingle(tankDTO.RealFcr) / 100 / tankDTO.RealFcr), 2 ),
                NewAverage = Math.Round(((tankDTO.AverageMass * Convert.ToSingle(tankDTO.Quantity)) + 
                              (tankDTO.AverageMass * Convert.ToSingle(tankDTO.Quantity) * Convert.ToSingle(tankDTO.RealFcr) / 100 / tankDTO.RealFcr)) / Convert.ToSingle(tankDTO.Quantity), 2),
                Density = Math.Round(tankDTO.AverageMass * Convert.ToSingle(tankDTO.Quantity) / Convert.ToSingle(tankDTO.Dimension), 2)

            };
            return res;
        }


    }
}