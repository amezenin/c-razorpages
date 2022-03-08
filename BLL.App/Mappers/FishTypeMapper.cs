using System;
using ee.itcollege.anmeze.Contract.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class FishTypeMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.FishType))
            {
                return MapFromDAL((internalDTO.FishType) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.FishType))
            {
                return MapFromBLL((externalDTO.FishType) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.FishType MapFromDAL(internalDTO.FishType fishType)
        {
            var res = fishType == null ? null : new externalDTO.FishType()
            {
                Id = fishType.Id,
                Species = fishType.Species,
                MinTemp = fishType.MinTemp,
                MaxTemp = fishType.MaxTemp,
                MaxNh = fishType.MaxNh,
                MaxNo = fishType.MaxNo,
                MaxDensity = fishType.MaxDensity,
            };
            return res;
        }
        
        public static internalDTO.FishType MapFromBLL(externalDTO.FishType fishType)
        {
            var res = fishType == null ? null : new internalDTO.FishType()
            {
                Id = fishType.Id,
                Species = fishType.Species,
                MinTemp = fishType.MinTemp,
                MaxTemp = fishType.MaxTemp,
                MaxNh = fishType.MaxNh,
                MaxNo = fishType.MaxNo,
                MaxDensity = fishType.MaxDensity,
            };
            return res;
        }
        
        
        public static externalDTO.FishTypeDTO MapFromDAL(internalDTO.FishTypeDTO fishTypeDTO)
        {
            var res = fishTypeDTO == null ? null : new externalDTO.FishTypeDTO()
            {
                Id = fishTypeDTO.Id,
               Species = fishTypeDTO.Species,
                MinTemp = fishTypeDTO.MinTemp,
                MaxTemp = fishTypeDTO.MaxTemp,
                MaxNh = fishTypeDTO.MaxNh,
                MaxNo = fishTypeDTO.MaxNo,
                MaxDensity = fishTypeDTO.MaxDensity,
                TankCount = fishTypeDTO.TankCount
            };
            return res;
        }

    }
}