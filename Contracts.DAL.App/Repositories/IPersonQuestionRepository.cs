using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.anmeze.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    
    public interface IPersonQuestionRepository: IPersonQuestionRepository<DALAppDTO.PersonQuestion>
    {
        
        
        
    }
    public interface IPersonQuestionRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()

    {
        Task<List<TDALEntity>> AllForUserAsync(int userId);
        Task<TDALEntity> FindForUserAsync(int id, int userId);
        Task<bool> BelongsToUserAsync(int id, int userId);


        
    }
}