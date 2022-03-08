using System;
using ee.itcollege.anmeze.Contracts.DAL.Base.Mappers;
using DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class AnsweredQuestionMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.AnsweredQuestion))
            {
                return MapFromDomain((Domain.AnsweredQuestion) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.AnsweredQuestion))
            {
                return MapFromDAL((DAL.App.DTO.AnsweredQuestion) inObject) as TOutObject;
            }

            throw new InvalidCastException("No conversion");
        }

        public static DAL.App.DTO.AnsweredQuestion MapFromDomain(Domain.AnsweredQuestion answeredQuestion)
        {
            var res = answeredQuestion == null ? null : new DAL.App.DTO.AnsweredQuestion
            {
                Id = answeredQuestion.Id,
                FarmerId = answeredQuestion.FarmerId,
                Farmer = FarmerMapper.MapFromDomain(answeredQuestion.Farmer),
                QuestionId = answeredQuestion.QuestionId,
                Question = QuestionMapper.MapFromDomain(answeredQuestion.Question),
            };


            return res;
        }

        public static Domain.AnsweredQuestion MapFromDAL(DAL.App.DTO.AnsweredQuestion answeredQuestion)
        {
            var res = answeredQuestion == null ? null : new Domain.AnsweredQuestion
            {
                Id = answeredQuestion.Id,
                FarmerId = answeredQuestion.FarmerId,
                Farmer = FarmerMapper.MapFromDAL(answeredQuestion.Farmer),
                QuestionId = answeredQuestion.QuestionId,
                Question = QuestionMapper.MapFromDAL(answeredQuestion.Question),
                
            };


            return res;
        }
    }
}