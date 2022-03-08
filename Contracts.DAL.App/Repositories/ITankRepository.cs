using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.anmeze.Contracts.DAL.Base.Repositories;
using DAL.App.DTO;
using DALAppDTO = DAL.App.DTO;


namespace Contracts.DAL.App.Repositories
{
    
    public interface ITankRepository: ITankRepository<DALAppDTO.Tank>
    {
        
        Task<List<DALAppDTO.TankDTO>> GetAllWithBiomassAsync(int userId);
        Task<DALAppDTO.TankDTO> GetTankWithBiomassAsync(int id, int userId);
        
        
    }
    public interface ITankRepository<TDALEntity> : IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {      
        
        
        
        Task<List<TDALEntity>> AllForUserAsync(int userId);
        Task<TDALEntity> FindForUserAsync(int id, int userId);
        
        Task<bool> BelongsToUserAsync(int id, int userId);
    }
}