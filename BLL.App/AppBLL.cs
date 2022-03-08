using System;
using ee.itcollege.anmeze.Contract.BLL.Base.Helpers;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.anmeze.Contracts.DAL.Base;


namespace BLL.App
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        protected readonly IAppUnitOfWork AppUnitOfWork;
        
        public AppBLL(IAppUnitOfWork unitOfWork, IBaseServiceProvider serviceProvider) : base(unitOfWork, serviceProvider)
        {
            AppUnitOfWork = unitOfWork;
        }
        

        public IAnswerService Answers => ServiceProvider.GetService<IAnswerService>();
        public IAnsweredQuestionsService AnsweredQuestions => ServiceProvider.GetService<IAnsweredQuestionsService>();
        public IEquipmentService Equipments => ServiceProvider.GetService<IEquipmentService>();
        public IEquipmentTypeService EquipmentTypes => ServiceProvider.GetService<IEquipmentTypeService>();
        public IFarmerService Farmers => ServiceProvider.GetService<IFarmerService>();
        public IFarmService Farms => ServiceProvider.GetService<IFarmService>();
        public IFishTypeService FishTypes => ServiceProvider.GetService<IFishTypeService>();
        public IPersonQuestionService PersonQuestions => ServiceProvider.GetService<IPersonQuestionService>();
        public IQuestionService Questions => ServiceProvider.GetService<IQuestionService>();
        public ISolutionService Solutions => ServiceProvider.GetService<ISolutionService>();
        public ITankService Tanks => ServiceProvider.GetService<ITankService>();


        
    }
}