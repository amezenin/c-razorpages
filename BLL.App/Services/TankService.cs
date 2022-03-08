using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using ee.itcollege.anmeze.BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using ee.itcollege.anmeze.Contracts.DAL.Base;
using DAL.App.DTO;
using Domain;
using Tank = BLL.App.DTO.Tank;
using TankDTO = BLL.App.DTO.TankDTO;

namespace BLL.App.Services
{
    public class TankService : BaseEntityService<BLL.App.DTO.Tank, DAL.App.DTO.Tank, IAppUnitOfWork>, ITankService
    {

        public TankService(IAppUnitOfWork uow) : base(uow, new TankMapper())
        {
            //ServiceRepository = Uow.BaseRepository<DAL.App.DTO.Tank, Domain.Tank>();
            ServiceRepository = Uow.Tanks;
        }

        public async Task<List<BLL.App.DTO.TankDTO>> GetAllWithBiomassAsync(int userId)
        {
            //throw new System.NotImplementedException();
            return (await Uow.Tanks.GetAllWithBiomassAsync(userId)).Select(e => TankMapper.MapFromDAL(e)).ToList();
        }

        


        public async Task<BLL.App.DTO.TankDTO> GetTankWithBiomassAsync(int id, int userId)
        {
            //throw new System.NotImplementedException();
            return TankMapper.MapFromDAL(await Uow.Tanks.GetTankWithBiomassAsync(id, userId));
        }


         

        public async Task<List<BLL.App.DTO.Tank>> AllForUserAsync(int userId)
        {
            return (await Uow.Tanks.AllForUserAsync(userId)).Select(e => TankMapper.MapFromDAL(e)).ToList();
        }

        public async Task<BLL.App.DTO.Tank> FindForUserAsync(int id, int userId)
        {
            return TankMapper.MapFromDAL(await Uow.Tanks.FindForUserAsync(id, userId));
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.Tanks.BelongsToUserAsync(id, userId);
        }

       
    }
}