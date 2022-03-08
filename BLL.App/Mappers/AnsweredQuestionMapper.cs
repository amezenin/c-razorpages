using System;
using ee.itcollege.anmeze.Contract.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class AnsweredQuestionMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.AnsweredQuestion))
            {
                return MapFromDAL((internalDTO.AnsweredQuestion) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.AnsweredQuestion))
            {
                return MapFromBLL((externalDTO.AnsweredQuestion) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.AnsweredQuestion MapFromDAL(internalDTO.AnsweredQuestion answeredQuestion)
        {
            var res = answeredQuestion == null ? null : new externalDTO.AnsweredQuestion
            {
                Id = answeredQuestion.Id,
                FarmerId = answeredQuestion.FarmerId,
                Farmer = FarmerMapper.MapFromDAL(answeredQuestion.Farmer),
                QuestionId = answeredQuestion.QuestionId,
                Question = QuestionMapper.MapFromDAL(answeredQuestion.Question),
                
            };

            return res;
        }

        public static internalDTO.AnsweredQuestion MapFromBLL(externalDTO.AnsweredQuestion answeredQuestion)
        {
            var res = answeredQuestion == null ? null : new internalDTO.AnsweredQuestion
            {
                Id = answeredQuestion.Id,
                FarmerId = answeredQuestion.FarmerId,
                Farmer = FarmerMapper.MapFromBLL(answeredQuestion.Farmer),
                QuestionId = answeredQuestion.QuestionId,
                Question = QuestionMapper.MapFromBLL(answeredQuestion.Question),
            };
            return res;
        }
    }
}