using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class EquipmentMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Equipment))
            {
                // map internalDTO to externalDTO
                return MapFromBLL((internalDTO.Equipment) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Equipment))
            {
                // map externalDTO to internalDTO
                return MapFromExternal((externalDTO.Equipment) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");

        }

        public static externalDTO.Equipment MapFromBLL(internalDTO.Equipment equipment)
        {
            var res = equipment == null ? null : new externalDTO.Equipment()
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
        
        public static internalDTO.Equipment MapFromExternal(externalDTO.Equipment equipment)
        {
            var res = equipment == null ? null : new internalDTO.Equipment()
            {
                Id = equipment.Id,
                FarmId = equipment.FarmId,
                Farm = FarmMapper.MapFromExternal(equipment.Farm),
                EquipmentTypeId = equipment.EquipmentTypeId,
                EquipmentType = EquipmentTypeMapper.MapFromExternal(equipment.EquipmentType),
                Name = equipment.Name
            };

            return res;
        }
    }
}