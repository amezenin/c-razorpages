using Contracts.DAL.App.Repositories;
using ee.itcollege.anmeze.Contracts.DAL.Base.Helpers;
using DAL.App.EF.Repositories;
using ee.itcollege.anmeze.DAL.Base.EF.Helpers;

namespace DAL.App.EF.Helpers
{
    public class AppRepositoryFactory : BaseRepositoryFactory<AppDbContext>
    {
        public AppRepositoryFactory()
        {
            
            RegisterRepositories();
            /*_repositoryCreationMethodCache.Add(typeof(IAnswerRepository), dataContext => new AnswerRepository(dataContext));
            _repositoryCreationMethodCache.Add(typeof(IAnsweredQuestionsRepository), dataContext => new AnsweredQuestionRepository(dataContext));
            _repositoryCreationMethodCache.Add(typeof(IEquipmentRepository), dataContext => new EquipmentRepository(dataContext));
            _repositoryCreationMethodCache.Add(typeof(IEquipmentTypeRepository), dataContext => new EquipmentTypeRepository(dataContext));
            _repositoryCreationMethodCache.Add(typeof(IFarmerRepository), dataContext => new FarmerRepository(dataContext));
            _repositoryCreationMethodCache.Add(typeof(IFarmRepository), dataContext => new FarmRepository(dataContext));
            _repositoryCreationMethodCache.Add(typeof(IFishTypeRepository), dataContext => new FishTypeRepository(dataContext));
            _repositoryCreationMethodCache.Add(typeof(IPersonQuestionRepository), dataContext => new PersonQuestionRepository(dataContext));
            _repositoryCreationMethodCache.Add(typeof(IQuestionRepository), dataContext => new QuestionRepository(dataContext));
            _repositoryCreationMethodCache.Add(typeof(ISolutionRepository), dataContext => new SolutionRepository(dataContext));
            _repositoryCreationMethodCache.Add(typeof(ITankRepository), dataContext => new TankRepository(dataContext));*/

        }

        private void RegisterRepositories()
        {
            AddToCreationMethods<IAnswerRepository>(dataContext => new AnswerRepository(dataContext));
            AddToCreationMethods<IAnsweredQuestionsRepository>(dataContext => new AnsweredQuestionRepository(dataContext));
            AddToCreationMethods<IEquipmentRepository>(dataContext => new EquipmentRepository(dataContext));
            AddToCreationMethods<IEquipmentTypeRepository>(dataContext => new EquipmentTypeRepository(dataContext));
            AddToCreationMethods<IFarmerRepository>(dataContext => new FarmerRepository(dataContext));
            AddToCreationMethods<IFarmRepository>(dataContext => new FarmRepository(dataContext));
            AddToCreationMethods<IFishTypeRepository>(dataContext => new FishTypeRepository(dataContext));
            AddToCreationMethods<IPersonQuestionRepository>(dataContext => new PersonQuestionRepository(dataContext));
            AddToCreationMethods<IQuestionRepository>(dataContext => new QuestionRepository(dataContext));
            AddToCreationMethods<ISolutionRepository>(dataContext => new SolutionRepository(dataContext));
            AddToCreationMethods<ITankRepository>(dataContext => new TankRepository(dataContext));
        }
    }
}