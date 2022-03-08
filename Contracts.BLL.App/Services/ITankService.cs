using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.anmeze.Contract.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface ITankService : IBaseEntityService<BLLAppDTO.Tank>, ITankRepository<BLLAppDTO.Tank>
    {
        Task<List<BLLAppDTO.TankDTO>> GetAllWithBiomassAsync(int userId);
        Task<BLLAppDTO.TankDTO> GetTankWithBiomassAsync(int id, int userId);


        
    }
}