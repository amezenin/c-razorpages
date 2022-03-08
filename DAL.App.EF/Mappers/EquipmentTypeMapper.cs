using System;
using ee.itcollege.anmeze.Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class EquipmentTypeMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.EquipmentType))
            {
                return MapFromDomain((Domain.EquipmentType) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.EquipmentType))
            {
                return MapFromDAL((DAL.App.DTO.EquipmentType) inObject) as TOutObject;
            }

            throw new InvalidCastException("No conversion");
        }


        public static DAL.App.DTO.EquipmentType MapFromDomain(Domain.EquipmentType equipmentType)
        {
            var res = equipmentType == null ? null : new DAL.App.DTO.EquipmentType()
            {
                Id = equipmentType.Id,
                Name = equipmentType.Name
            };
            return res;

        }
        
        public static Domain.EquipmentType MapFromDAL(DAL.App.DTO.EquipmentType equipmentType)
        {
            var res = equipmentType == null ? null : new Domain.EquipmentType()
            {
                Id = equipmentType.Id,
                Name = equipmentType.Name,
                
            };
            return res;

        }
        
        
    }
}