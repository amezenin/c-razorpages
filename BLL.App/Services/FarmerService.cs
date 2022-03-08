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
    public class FarmerService : BaseEntityService<BLL.App.DTO.Farmer, DAL.App.DTO.Farmer, IAppUnitOfWork>, IFarmerService
    {

        public FarmerService(IAppUnitOfWork uow) : base(uow, new FarmerMapper())
        {
            //ServiceRepository = Uow.BaseRepository<DAL.App.DTO.Farmer, Domain.Farmer>();
            ServiceRepository = Uow.Farmers;
        }
        
        public async Task<List<BLL.App.DTO.Farmer>> AllForUserAsync(int userId)
        {
            return (await Uow.Farmers.AllForUserAsync(userId)).Select(e => FarmerMapper.MapFromDAL(e)).ToList();
        }

        public async Task<BLL.App.DTO.Farmer> FindForUserAsync(int id, int userId)
        {
            return FarmerMapper.MapFromDAL( await Uow.Farmers.FindForUserAsync(id, userId));
        }

        public async  Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.Farmers.BelongsToUserAsync(id, userId);
        }
    }
}