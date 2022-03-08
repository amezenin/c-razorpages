using System;
using System.Collections.Generic;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using ee.itcollege.anmeze.Contracts.DAL.Base;
using ee.itcollege.anmeze.Contracts.DAL.Base.Helpers;
using DAL.App.EF.Repositories;
using ee.itcollege.anmeze.DAL.Base.EF;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbContext dbContext, IBaseRepositoryProvider repositoryProvider) : base(dbContext, repositoryProvider)
        {
        }

        public IAnswerRepository Answers => 
            _repositoryProvider.GetRepository<IAnswerRepository>();
        public IAnsweredQuestionsRepository AnsweredQuestions => 
            _repositoryProvider.GetRepository<IAnsweredQuestionsRepository>();
        public IEquipmentRepository Equipments => 
            _repositoryProvider.GetRepository<IEquipmentRepository>();
        public IEquipmentTypeRepository EquipmentTypes => 
            _repositoryProvider.GetRepository<IEquipmentTypeRepository>();
        public IFarmerRepository Farmers => 
            _repositoryProvider.GetRepository<IFarmerRepository>();
        public IFarmRepository Farms => 
            _repositoryProvider.GetRepository<IFarmRepository>();
        public IFishTypeRepository FishTypes => 
            _repositoryProvider.GetRepository<IFishTypeRepository>();
        public IPersonQuestionRepository PersonQuestions => 
            _repositoryProvider.GetRepository<IPersonQuestionRepository>();
        public IQuestionRepository Questions => 
            _repositoryProvider.GetRepository<IQuestionRepository>();
        public ISolutionRepository Solutions => 
            _repositoryProvider.GetRepository<ISolutionRepository>();
        public ITankRepository Tanks => 
            _repositoryProvider.GetRepository<ITankRepository>();
        
        
       
        
        
    }
}