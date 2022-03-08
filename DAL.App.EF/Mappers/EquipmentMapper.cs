using System;
using ee.itcollege.anmeze.Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class EquipmentMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.Equipment))
            {
                return MapFromDomain((Domain.Equipment) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Equipment))
            {
                return MapFromDAL((DAL.App.DTO.Equipment) inObject) as TOutObject;
            }

            throw new InvalidCastException("No conversion");
        }

        public static DAL.App.DTO.Equipment MapFromDomain(Domain.Equipment equipment)
        {
            var res = equipment == null ? null : new DAL.App.DTO.Equipment
            {
                Id = equipment.Id,
                FarmId = equipment.FarmId,
                Farm = FarmMapper.MapFromDomain(equipment.Farm),
                EquipmentTypeId = equipment.EquipmentTypeId,
                EquipmentType = EquipmentTypeMapper.MapFromDomain(equipment.EquipmentType),
                Name = equipment.Name
            };


            return res;



           
            

            return res;
        }

        public static Domain.Equipment MapFromDAL(DAL.App.DTO.Equipment equipment)
        {
            var res = equipment == null ? null : new Domain.Equipment
            {
                Id = equipment.Id,
                FarmId = equipment.FarmId,
                Farm = FarmMapper.MapFromDAL(equipment.Farm),
                EquipmentTypeId = equipment.EquipmentTypeId,
                EquipmentType = EquipmentTypeMapper.MapFromDAL(equipment.EquipmentType),
                Name = equipment.Name
            };


            return res;

        }
    }
}