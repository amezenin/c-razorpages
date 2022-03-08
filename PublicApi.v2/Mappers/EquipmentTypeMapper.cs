using System;
using externalDTO = PublicApi.v2.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v2.Mappers
{
    public class EquipmentTypeMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.EquipmentType))
            {
                // map internalDTO to externalDTO
                return MapFromBLL((internalDTO.EquipmentType) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.EquipmentType))
            {
                // map externalDTO to internalDTO
                return MapFromExternal((externalDTO.EquipmentType) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");

        }

        public static externalDTO.EquipmentType MapFromBLL(internalDTO.EquipmentType equipmentType)
        {
            var res = equipmentType == null ? null : new externalDTO.EquipmentType()
            {
                Id = equipmentType.Id,
                Name = equipmentType.Name,
            };

            return res;
        }
        
        public static internalDTO.EquipmentType MapFromExternal(externalDTO.EquipmentType equipmentType)
        {
            var res = equipmentType == null ? null : new internalDTO.EquipmentType()
            {
                Id = equipmentType.Id,
                Name = equipmentType.Name,
            };

            return res;
        }
        
        public static externalDTO.EquipmentTypeDTO MapFromBLL(internalDTO.EquipmentTypeDTO equipmentTypeDto)
        {
            var res = equipmentTypeDto == null ? null : new externalDTO.EquipmentTypeDTO()
            {
                Id = equipmentTypeDto.Id,
                Name = equipmentTypeDto.Name,
                EquipmentsCount = equipmentTypeDto.EquipmentsCount + 2000
            };
            return res;
        }

    }
}