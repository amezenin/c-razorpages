using System;
using externalDTO = PublicApi.v2.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v2.Mappers
{
    public class FarmerMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Farmer))
            {
                // map internalDTO to externalDTO
                return MapFromBLL((internalDTO.Farmer) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Farmer))
            {
                // map externalDTO to internalDTO
                return MapFromExternal((externalDTO.Farmer) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");

        }

        public static externalDTO.Farmer MapFromBLL(internalDTO.Farmer farmer)
        {
            var res = farmer == null ? null : new externalDTO.Farmer()
            {
                Id = farmer.Id,
                Firstname = farmer.Firstname,
                Lastname = farmer.Lastname,
                Score = farmer.Score,
                AppUserId = farmer.AppUserId,
            };

            return res;
        }
        
        public static internalDTO.Farmer MapFromExternal(externalDTO.Farmer farmer)
        {
            var res = farmer == null ? null : new internalDTO.Farmer()
            {
                Id = farmer.Id,
                Firstname = farmer.Firstname,
                Lastname = farmer.Lastname,
                Score = farmer.Score,
                AppUserId = farmer.AppUserId,
            };

            return res;
        }
    }
}