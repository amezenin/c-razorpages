using System;
using ee.itcollege.anmeze.Contract.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class EquipmentTypeMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.EquipmentType))
            {
                return MapFromDAL((internalDTO.EquipmentType) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.EquipmentType))
            {
                return MapFromBLL((externalDTO.EquipmentType) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.EquipmentType MapFromDAL(internalDTO.EquipmentType equipmentType)
        {
            var res = equipmentType == null ? null : new externalDTO.EquipmentType()
            {
                Id = equipmentType.Id,
                Name = equipmentType.Name,
            };
            return res;
        }
        
        public static internalDTO.EquipmentType MapFromBLL(externalDTO.EquipmentType equipmentType)
        {
            var res = equipmentType == null ? null : new internalDTO.EquipmentType()
            {
                Id = equipmentType.Id,
                Name = equipmentType.Name,
            };
            return res;
        }
        
        public static externalDTO.EquipmentTypeDTO MapFromDAL(internalDTO.EquipmentTypeDTO equipmentTypeDTO)
        {
            var res = equipmentTypeDTO == null ? null : new externalDTO.EquipmentTypeDTO()
            {
                Id = equipmentTypeDTO.Id,
                 Name = equipmentTypeDTO.Name,
                 EquipmentsCount = equipmentTypeDTO.EquipmentsCount
            };
            return res;
        }
    }
}