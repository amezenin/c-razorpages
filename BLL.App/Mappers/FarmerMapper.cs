using System;
using ee.itcollege.anmeze.Contract.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class FarmerMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Farmer))
            {
                return MapFromDAL((internalDTO.Farmer) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Farmer))
            {
                return MapFromBLL((externalDTO.Farmer) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Farmer MapFromDAL(internalDTO.Farmer farmer)
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
        
        public static internalDTO.Farmer MapFromBLL(externalDTO.Farmer farmer)
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