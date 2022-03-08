using System;
using externalDTO = PublicApi.v2.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v2.Mappers
{
    public class TankMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Tank))
            {
                // map internalDTO to externalDTO
                return MapFromBLL((internalDTO.Tank) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Tank))
            {
                // map externalDTO to internalDTO
                return MapFromExternal((externalDTO.Tank) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");

        }

        public static externalDTO.Tank MapFromBLL(internalDTO.Tank tank)
        {
            var res = tank == null ? null : new externalDTO.Tank()
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
        
        public static internalDTO.Tank MapFromExternal(externalDTO.Tank tank)
        {
            var res = tank == null ? null : new internalDTO.Tank()
            {
                Id = tank.Id,
                FarmId = tank.FarmId,
                Farm = FarmMapper.MapFromExternal(tank.Farm),
                FishTypeId = tank.FishTypeId,
                FishType = FishTypeMapper.MapFromExternal(tank.FishType),
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
        
        public static externalDTO.TankDTO MapFromBLL(internalDTO.TankDTO tankDTO)
        {
            var res = tankDTO == null ? null : new externalDTO.TankDTO()
            {
                Id = tankDTO.Id,
                FarmId = tankDTO.FarmId,
                Farm = FarmMapper.MapFromBLL(tankDTO.Farm),
                FishTypeId = tankDTO.FishTypeId,
                FishType = FishTypeMapper.MapFromBLL(tankDTO.FishType),
                Name = tankDTO.Name,
                Dimension = tankDTO.Dimension,
                Quantity = tankDTO.Quantity,
                AverageMass = tankDTO.AverageMass,
                RealFcr = tankDTO.RealFcr,
                RealNh = tankDTO.RealNh,
                RealNo = tankDTO.RealNo,  
                Biomass = tankDTO.AverageMass * tankDTO.Quantity
            };
            return res;
        }
    }
}