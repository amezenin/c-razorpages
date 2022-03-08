using Contracts.DAL.App.Repositories;
using ee.itcollege.anmeze.Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IAnswerRepository Answers { get; }
        IAnsweredQuestionsRepository AnsweredQuestions { get; }
        IEquipmentRepository Equipments { get; }
        IEquipmentTypeRepository EquipmentTypes { get; }
        IFarmerRepository Farmers { get; }
        IFarmRepository Farms { get; }
        IFishTypeRepository FishTypes { get; }
        IPersonQuestionRepository PersonQuestions { get; }
        IQuestionRepository Questions { get; }
        ISolutionRepository Solutions { get; }
        ITankRepository Tanks { get; }
    }
}