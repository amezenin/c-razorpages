using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using ee.itcollege.anmeze.BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.anmeze.Contracts.DAL.Base;
using Domain;

namespace BLL.App.Services
{
    public class SolutionService : BaseEntityService<BLL.App.DTO.Solution, DAL.App.DTO.Solution, IAppUnitOfWork>, ISolutionService
    {

        public SolutionService(IAppUnitOfWork uow) : base(uow, new SolutionMapper())
        {
            //just with whit didnt show question text in controllers
            //ServiceRepository = Uow.BaseRepository<DAL.App.DTO.Solution, Domain.Solution>();
            ServiceRepository = Uow.Solutions;
        }
        
        public async Task<List<BLL.App.DTO.Solution>> AllForUserAsync(int userId)
        {
            return (await Uow.Solutions.AllForUserAsync(userId)).Select(e => SolutionMapper.MapFromDAL(e)).ToList();
        }

        public async Task<BLL.App.DTO.Solution> FindForUserAsync(int id, int userId)
        {
            return SolutionMapper.MapFromDAL(await Uow.Solutions.FindForUserAsync(id, userId));
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.Solutions.BelongsToUserAsync(id, userId);
        }

        
    }
}