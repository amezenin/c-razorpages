using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.anmeze.Contract.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IEquipmentService : IBaseEntityService<BLLAppDTO.Equipment>, IEquipmentRepository<BLLAppDTO.Equipment>
    {
        
    }
}