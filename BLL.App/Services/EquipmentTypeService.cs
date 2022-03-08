using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.Mappers;
using ee.itcollege.anmeze.BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;


namespace BLL.App.Services
{
    public class EquipmentTypeService : BaseEntityService<BLL.App.DTO.EquipmentType, DAL.App.DTO.EquipmentType, IAppUnitOfWork>, IEquipmentTypeService
    {

        public EquipmentTypeService(IAppUnitOfWork uow) : base(uow, new EquipmentTypeMapper())
        {
            //ServiceRepository = Uow.BaseRepository<DAL.App.DTO.EquipmentType, Domain.EquipmentType>();
            ServiceRepository = Uow.EquipmentTypes;
        }

        public async Task<List<BLL.App.DTO.EquipmentTypeDTO>> GetAllWithEquipmentTypeCountAsync()
        {
            //throw new System.NotImplementedException();
            return (await Uow.EquipmentTypes.GetAllWithEquipmentCountAsync()).Select(e => EquipmentTypeMapper.MapFromDAL(e)).ToList();
        }
        
        
        //not need
        public async Task<List<BLL.App.DTO.EquipmentType>> AllForUserAsync(int userId)
        {
            return (await Uow.EquipmentTypes.AllForUserAsync(userId)).Select(e => EquipmentTypeMapper.MapFromDAL(e)).ToList();
        }

        public async Task<BLL.App.DTO.EquipmentType> FindForUserAsync(int id, int userId)
        {
            return EquipmentTypeMapper.MapFromDAL(await Uow.EquipmentTypes.FindForUserAsync(id, userId));
        }

        
    }
}