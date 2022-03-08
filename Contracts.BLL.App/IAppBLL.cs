using System;
using ee.itcollege.anmeze.Contract.BLL.Base;
using Contracts.BLL.App.Services;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        IAnswerService Answers { get; }
        IAnsweredQuestionsService AnsweredQuestions { get; }
        IEquipmentService Equipments { get; }
        IEquipmentTypeService EquipmentTypes { get; }
        IFarmerService Farmers { get; }
        IFarmService Farms { get; }
        IFishTypeService FishTypes { get; }
        IPersonQuestionService PersonQuestions { get; }
        IQuestionService Questions { get; }
        ISolutionService Solutions { get; }
        ITankService Tanks { get; }
        
        //todo: something
        //IContactBookService ContactBooks
    }
}