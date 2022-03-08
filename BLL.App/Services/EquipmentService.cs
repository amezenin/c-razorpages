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
    public class EquipmentService : BaseEntityService<BLL.App.DTO.Equipment, DAL.App.DTO.Equipment, IAppUnitOfWork>, IEquipmentService
    {

        public EquipmentService(IAppUnitOfWork uow) : base(uow, new EquipmentMapper())
        {
            //ServiceRepository = Uow.BaseRepository<DAL.App.DTO.Equipment, Domain.Equipment>();
            ServiceRepository = Uow.Equipments;
        }
        
        public async Task<List<BLL.App.DTO.Equipment>> AllForUserAsync(int userId)
        {
            return (await Uow.Equipments.AllForUserAsync(userId)).Select(e => EquipmentMapper.MapFromDAL(e)).ToList();
        }

        public async Task<BLL.App.DTO.Equipment> FindForUserAsync(int id, int userId)
        {
            return EquipmentMapper.MapFromDAL(await Uow.Equipments.FindForUserAsync(id, userId));
        }
        
        
        
        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.Equipments.BelongsToUserAsync(id, userId);
        }
        
    }
}