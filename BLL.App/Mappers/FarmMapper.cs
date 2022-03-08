using System;
using ee.itcollege.anmeze.Contract.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class FarmMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Farm))
            {
                return MapFromDAL((internalDTO.Farm) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Farm))
            {
                return MapFromBLL((externalDTO.Farm) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Farm MapFromDAL(internalDTO.Farm farm)
        {
            var res = farm == null ? null : new externalDTO.Farm
            {
                Id = farm.Id,
                FarmerId = farm.FarmerId,
                Farmer = FarmerMapper.MapFromDAL(farm.Farmer),
                Name = farm.Name,
                Location = farm.Location
            };

            return res;
        }

        public static internalDTO.Farm MapFromBLL(externalDTO.Farm farm)
        {
            var res = farm == null ? null : new internalDTO.Farm
            {
                Id = farm.Id,
                FarmerId = farm.FarmerId,
                Farmer = FarmerMapper.MapFromBLL(farm.Farmer),
                Name = farm.Name,
                Location = farm.Location
            };
            return res;
        }

    }
}