using System;
using ee.itcollege.anmeze.Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class FarmerMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.Farmer))
            {
                return MapFromDomain((Domain.Farmer) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Farmer))
            {
                return MapFromDAL((DAL.App.DTO.Farmer) inObject) as TOutObject;
            }

            throw new InvalidCastException("No conversion");
        }


        public static DAL.App.DTO.Farmer MapFromDomain(Domain.Farmer farmer)
        {
            var res = farmer == null ? null : new DAL.App.DTO.Farmer()
            {
                Id = farmer.Id,
                Firstname = farmer.Firstname,
                Lastname = farmer.Lastname,
                Score = farmer.Score,
                AppUserId = farmer.AppUserId,
               
            };

            return res;

        }
        
        public static Domain.Farmer MapFromDAL(DAL.App.DTO.Farmer farmer)
        {
            var res = farmer == null ? null : new Domain.Farmer()
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