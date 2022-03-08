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
    public class AnsweredQuestionsService : BaseEntityService<BLL.App.DTO.AnsweredQuestion, DAL.App.DTO.AnsweredQuestion, IAppUnitOfWork>, IAnsweredQuestionsService
    {

        public AnsweredQuestionsService(IAppUnitOfWork uow) : base(uow, new AnsweredQuestionMapper())
        {
            //ServiceRepository = Uow.BaseRepository<DAL.App.DTO.AnsweredQuestion, Domain.AnsweredQuestion>();
            ServiceRepository = Uow.AnsweredQuestions;

        }
        
        
        public async Task<List<BLL.App.DTO.AnsweredQuestion>> AllForUserAsync(int userId)
        {
            return (await Uow.AnsweredQuestions.AllForUserAsync(userId)).Select(e => AnsweredQuestionMapper.MapFromDAL(e)).ToList();
        }

        public async Task<BLL.App.DTO.AnsweredQuestion> FindForUserAsync(int id, int userId)
        {
            return AnsweredQuestionMapper.MapFromDAL( await Uow.AnsweredQuestions.FindForUserAsync(id, userId));
        }
        
        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.AnsweredQuestions.BelongsToUserAsync(id, userId);
        }


        
    }
}