using System;
using ee.itcollege.anmeze.Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class TankMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.Tank))
            {
                return MapFromDomain((Domain.Tank) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Tank))
            {
                return MapFromDAL((DAL.App.DTO.Tank) inObject) as TOutObject;
            }

            throw new InvalidCastException("No conversion");
        }

        public static DAL.App.DTO.Tank MapFromDomain(Domain.Tank tank)
        {
            var res = tank == null ? null : new DAL.App.DTO.Tank
            {
                Id = tank.Id,
                FarmId = tank.FarmId,
                Farm = FarmMapper.MapFromDomain(tank.Farm),
                FishTypeId = tank.FishTypeId,
                FishType = FishTypeMapper.MapFromDomain(tank.FishType),
                Name = tank.Name,
                Dimension = tank.Dimension,
                Quantity = tank.Quantity,
                AverageMass = tank.AverageMass,
                RealNh = tank.RealNh,
                RealNo = tank.RealNo,
                RealFcr = tank.RealFcr
                
            };

            
            return res;

        }

        public static Domain.Tank MapFromDAL(DAL.App.DTO.Tank tank)
        {
            var res = tank == null ? null : new Domain.Tank
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
                RealNh = tank.RealNh,
                RealNo = tank.RealNo,
                RealFcr = tank.RealFcr
            };


            return res;
        }


    }
}