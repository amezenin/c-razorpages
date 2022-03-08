using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.anmeze.Contract.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IEquipmentTypeService : IBaseEntityService<BLLAppDTO.EquipmentType>, IEquipmentTypeRepository<BLLAppDTO.EquipmentType>
    {
        Task<List<BLLAppDTO.EquipmentTypeDTO>> GetAllWithEquipmentTypeCountAsync();
    }
}