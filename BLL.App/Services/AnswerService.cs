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
    public class AnswerService : BaseEntityService<BLL.App.DTO.Answer, DAL.App.DTO.Answer, IAppUnitOfWork>, IAnswerService
    {
        

        public AnswerService(IAppUnitOfWork uow) : base(uow, new AnswerMapper())
        {
            //ServiceRepository = Uow.BaseRepository<DAL.App.DTO.Answer, Domain.Answer>();
            ServiceRepository = Uow.Answers;
        }
        
        public async Task<List<BLL.App.DTO.Answer>> AllForUserAsync(int userId)
        {
            return (await Uow.Answers.AllForUserAsync(userId)).Select(e => AnswerMapper.MapFromDAL(e)).ToList();
        }

        public async Task<BLL.App.DTO.Answer> FindForUserAsync(int id, int userId)
        {
            return AnswerMapper.MapFromDAL( await Uow.Answers.FindForUserAsync(id, userId));
        }
        
        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.Equipments.BelongsToUserAsync(id, userId);
        }


    }
}