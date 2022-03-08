using System;
using ee.itcollege.anmeze.Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class FishTypeMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.FishType))
            {
                return MapFromDomain((Domain.FishType) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.FishType))
            {
                return MapFromDAL((DAL.App.DTO.FishType) inObject) as TOutObject;
            }

            throw new InvalidCastException("No conversion");
        }


        public static DAL.App.DTO.FishType MapFromDomain(Domain.FishType fishType)
        {
            var res = fishType == null ? null : new DAL.App.DTO.FishType()
            {
                Id = fishType.Id,
                Species = fishType.Species,
                MinTemp = fishType.MinTemp,
                MaxTemp = fishType.MaxTemp,
                MaxNh = fishType.MaxNh,
                MaxNo = fishType.MaxNo,
                MaxDensity = fishType.MaxDensity
            };
            return res;

        }
        
        public static Domain.FishType MapFromDAL(DAL.App.DTO.FishType fishType)
        {
            var res = fishType == null ? null : new Domain.FishType()
            {
                Id = fishType.Id,
                Species = fishType.Species,
                MinTemp = fishType.MinTemp,
                MaxTemp = fishType.MaxTemp,
                MaxNh = fishType.MaxNh,
                MaxNo = fishType.MaxNo,
                MaxDensity = fishType.MaxDensity
            };
            return res;

        }


    }
}