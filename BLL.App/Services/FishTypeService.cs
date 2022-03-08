using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using ee.itcollege.anmeze.BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.anmeze.Contracts.DAL.Base;
using DAL.App.DTO;
using Domain;
using FishType = BLL.App.DTO.FishType;
using FishTypeDTO = BLL.App.DTO.FishTypeDTO;


namespace BLL.App.Services
{
    public class FishTypeService : BaseEntityService<BLL.App.DTO.FishType, DAL.App.DTO.FishType, IAppUnitOfWork>, IFishTypeService
    {

        public FishTypeService(IAppUnitOfWork uow) : base(uow, new FishTypeMapper())
        {
            //ServiceRepository = Uow.BaseRepository<DAL.App.DTO.FishType, Domain.FishType>();
            ServiceRepository = Uow.FishTypes;
        }

        public async Task<List<BLL.App.DTO.FishTypeDTO>> GetAllWithFishTypeCountAsync()
        {
           // throw new System.NotImplementedException();
           return (await Uow.FishTypes.GetAllWithTankCountAsync()).Select(e => FishTypeMapper.MapFromDAL(e)).ToList();
        }
        
        public async Task<List<BLL.App.DTO.FishType>> AllForUserAsync(int userId)
        {
            return (await Uow.FishTypes.AllForUserAsync(userId)).Select(e => FishTypeMapper.MapFromDAL(e)).ToList();
        }

        public async Task<BLL.App.DTO.FishType> FindForUserAsync(int id, int userId)
        {
            return FishTypeMapper.MapFromDAL(await Uow.FishTypes.FindForUserAsync(id, userId));
        }

        
    }
}