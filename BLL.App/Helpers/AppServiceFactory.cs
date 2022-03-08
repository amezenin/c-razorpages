using BLL.App.Services;
using ee.itcollege.anmeze.BLL.Base.Helpers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Helpers
{
    public class AppServiceFactory : BaseServiceFactory<IAppUnitOfWork>
    {
        public AppServiceFactory()
        {
            
            RegisterServices();
            
        }

        private void RegisterServices()
        {
           
            
            AddToCreationMethods<IAnswerService>(uow => new AnswerService(uow));
            AddToCreationMethods<IAnsweredQuestionsService>(uow => new AnsweredQuestionsService(uow));
            AddToCreationMethods<IEquipmentService>(uow => new EquipmentService(uow));
            AddToCreationMethods<IEquipmentTypeService>(uow => new EquipmentTypeService(uow));
            AddToCreationMethods<IFarmerService>(uow => new FarmerService(uow));
            AddToCreationMethods<IFarmService>(uow => new FarmService(uow));
            AddToCreationMethods<IFishTypeService>(uow => new FishTypeService(uow));
            AddToCreationMethods<IPersonQuestionService>(uow => new PersonQuestionService(uow));
            AddToCreationMethods<IQuestionService>(uow => new QuestionService(uow));
            AddToCreationMethods<ISolutionService>(uow => new SolutionService(uow));
            AddToCreationMethods<ITankService>(uow => new TankService(uow));
        }

    }
}