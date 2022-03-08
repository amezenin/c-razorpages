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
    public class QuestionService : BaseEntityService<BLL.App.DTO.Question, DAL.App.DTO.Question, IAppUnitOfWork>, IQuestionService
    {

        public QuestionService(IAppUnitOfWork uow) : base(uow, new QuestionMapper())
        {
            //ServiceRepository = Uow.BaseRepository<DAL.App.DTO.Question, Domain.Question>();
            ServiceRepository = Uow.Questions;
        }
        
        public async Task<List<BLL.App.DTO.Question>> AllForUserAsync(int userId)
        {
            return (await Uow.Questions.AllForUserAsync(userId)).Select(e => QuestionMapper.MapFromDAL(e)).ToList();
        }

        public async Task<BLL.App.DTO.Question> FindForUserAsync(int id, int userId)
        {
            return QuestionMapper.MapFromDAL(await Uow.Questions.FindForUserAsync(id, userId));
        }
        
        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.Questions.BelongsToUserAsync(id, userId);
        }
        
    }
}