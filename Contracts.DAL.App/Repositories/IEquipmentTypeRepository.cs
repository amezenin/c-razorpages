using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.anmeze.Contracts.DAL.Base.Repositories;
using DAL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IEquipmentTypeRepository: IEquipmentTypeRepository<DALAppDTO.EquipmentType>
    {
        Task<List<DALAppDTO.EquipmentTypeDTO>> GetAllWithEquipmentCountAsync();
        
        
        
    }
    
    public interface IEquipmentTypeRepository<TDALEntity> : IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {      
        Task<List<TDALEntity>> AllForUserAsync(int userId);
        Task<TDALEntity> FindForUserAsync(int id, int userId);
        
    }
}