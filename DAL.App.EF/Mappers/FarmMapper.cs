using System;
using ee.itcollege.anmeze.Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class FarmMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.Farm))
            {
                return MapFromDomain((Domain.Farm) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Farm))
            {
                return MapFromDAL((DAL.App.DTO.Farm) inObject) as TOutObject;
            }

            throw new InvalidCastException("No conversion");
        }

        public static DAL.App.DTO.Farm MapFromDomain(Domain.Farm farm)
        {
            var res = farm == null ? null : new DAL.App.DTO.Farm
            {
                Id = farm.Id,
                FarmerId = farm.FarmerId,
                Farmer = FarmerMapper.MapFromDomain(farm.Farmer),
                Location = farm.Location,
                Name = farm.Name,
                
                
            };


            return res;
        }

        public static Domain.Farm MapFromDAL(DAL.App.DTO.Farm farm)
        {
            var res = farm == null ? null : new Domain.Farm
            {
                Id = farm.Id,
                FarmerId = farm.FarmerId,
                Farmer = FarmerMapper.MapFromDAL(farm.Farmer),
                Location = farm.Location,
                Name = farm.Name,
                
                
            };


            return res;
        }

        
    }
}