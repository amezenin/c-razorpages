using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class FarmMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Farm))
            {
                // map internalDTO to externalDTO
                return MapFromBLL((internalDTO.Farm) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Farm))
            {
                // map externalDTO to internalDTO
                return MapFromExternal((externalDTO.Farm) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");

        }

        public static externalDTO.Farm MapFromBLL(internalDTO.Farm farm)
        {
            var res = farm == null ? null : new externalDTO.Farm()
            {
                Id = farm.Id,
                FarmerId = farm.FarmerId,
                Farmer = FarmerMapper.MapFromBLL(farm.Farmer),
                Name = farm.Name,
                Location = farm.Location
            };

            return res;
        }
        
        public static internalDTO.Farm MapFromExternal(externalDTO.Farm farm)
        {
            var res = farm == null ? null : new internalDTO.Farm()
            {
                Id = farm.Id,
                FarmerId = farm.FarmerId,
                Farmer = FarmerMapper.MapFromExternal(farm.Farmer),
                Name = farm.Name,
                Location = farm.Location
            };

            return res;
        }
    }
}