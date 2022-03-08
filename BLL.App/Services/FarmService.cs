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
    public class FarmService : BaseEntityService<BLL.App.DTO.Farm, DAL.App.DTO.Farm, IAppUnitOfWork>, IFarmService
    {

        public FarmService(IAppUnitOfWork uow) : base(uow, new FarmMapper())
        {
            //ServiceRepository = Uow.BaseRepository<DAL.App.DTO.Farm, Domain.Farm>();
            ServiceRepository = Uow.Farms;
        }
        
        public async Task<List<BLL.App.DTO.Farm>> AllForUserAsync(int userId)
        {
            return (await Uow.Farms.AllForUserAsync(userId)).Select(e => FarmMapper.MapFromDAL(e)).ToList();
        }

        public async Task<BLL.App.DTO.Farm> FindForUserAsync(int id, int userId)
        {
            return FarmMapper.MapFromDAL(await Uow.Farms.FindForUserAsync(id, userId));
        }
        
        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.Farms.BelongsToUserAsync(id, userId);
        }

        
    }
}