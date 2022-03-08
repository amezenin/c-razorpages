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
    public class PersonQuestionService : BaseEntityService<BLL.App.DTO.PersonQuestion, DAL.App.DTO.PersonQuestion, IAppUnitOfWork>, IPersonQuestionService
    {

        public PersonQuestionService(IAppUnitOfWork uow) : base(uow, new PersonQuestionMapper())
        {
            //ServiceRepository = Uow.BaseRepository<DAL.App.DTO.PersonQuestion, Domain.PersonQuestion>();
            ServiceRepository = Uow.PersonQuestions;
        }
        
        public async Task<List<BLL.App.DTO.PersonQuestion>> AllForUserAsync(int userId)
        {
            return (await Uow.PersonQuestions.AllForUserAsync(userId)).Select(e => PersonQuestionMapper.MapFromDAL(e)).ToList();
        }

        public async Task<BLL.App.DTO.PersonQuestion> FindForUserAsync(int id, int userId)
        {
            return PersonQuestionMapper.MapFromDAL(await Uow.PersonQuestions.FindForUserAsync(id, userId));
        }
        
        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.PersonQuestions.BelongsToUserAsync(id, userId);
        }

        
    }
}