using System;
using ee.itcollege.anmeze.Contract.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class EquipmentMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Equipment))
            {
                return MapFromDAL((internalDTO.Equipment) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Equipment))
            {
                return MapFromBLL((externalDTO.Equipment) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Equipment MapFromDAL(internalDTO.Equipment equipment)
        {
            var res = equipment == null ? null : new externalDTO.Equipment
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

        public static internalDTO.Equipment MapFromBLL(externalDTO.Equipment equipment)
        {
            var res = equipment == null ? null : new internalDTO.Equipment
            {
                Id = equipment.Id,
                FarmId = equipment.FarmId,
                Farm = FarmMapper.MapFromBLL(equipment.Farm),
                EquipmentTypeId = equipment.EquipmentTypeId,
                EquipmentType = EquipmentTypeMapper.MapFromBLL(equipment.EquipmentType),
                Name = equipment.Name
            };
            return res;
        }

    }
}