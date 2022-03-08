using System;
using externalDTO = PublicApi.v2.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v2.Mappers
{
    public class FishTypeMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.FishType))
            {
                // map internalDTO to externalDTO
                return MapFromBLL((internalDTO.FishType) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.FishType))
            {
                // map externalDTO to internalDTO
                return MapFromExternal((externalDTO.FishType) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");

        }

        public static externalDTO.FishType MapFromBLL(internalDTO.FishType fishType)
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
        
        public static internalDTO.FishType MapFromExternal(externalDTO.FishType fishType)
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
        
        public static externalDTO.FishTypeDTO MapFromBLL(internalDTO.FishTypeDTO fishTypeDto)
        {
            var res = fishTypeDto == null ? null : new externalDTO.FishTypeDTO()
            {
                Id = fishTypeDto.Id,
                Species = fishTypeDto.Species,
                MinTemp = fishTypeDto.MinTemp,
                MaxTemp = fishTypeDto.MaxTemp,
                MaxNh = fishTypeDto.MaxNh,
                MaxNo = fishTypeDto.MaxNo,
                MaxDensity = fishTypeDto.MaxDensity,
                TankCount = fishTypeDto.TankCount
            };
            return res;
        }
    }
}