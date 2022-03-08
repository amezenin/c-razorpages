using System;
using ee.itcollege.anmeze.Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class AnswerMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.Answer))
            {
                return MapFromDomain((Domain.Answer) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Answer))
            {
                return MapFromDAL((DAL.App.DTO.Answer) inObject) as TOutObject;
            }

            throw new InvalidCastException("No conversion");
        }


        public static DAL.App.DTO.Answer MapFromDomain(Domain.Answer answer)
        {
            var res = answer == null ? null : new DAL.App.DTO.Answer()
            {
                Id = answer.Id,
                AnswerValueFirst = answer.AnswerValueFirst,
                AnswerValueSecond = answer.AnswerValueSecond,
                AnswerValueThird = answer.AnswerValueThird,
                QuestionId = answer.QuestionId,
                Question = QuestionMapper.MapFromDomain(answer.Question),
               
            };
            return res;

        }
        
        public static Domain.Answer MapFromDAL(DAL.App.DTO.Answer answer)
        {
            var res = answer == null ? null : new Domain.Answer()
            {
                Id = answer.Id,
                AnswerValueFirst = answer.AnswerValueFirst,
                AnswerValueSecond = answer.AnswerValueSecond,
                AnswerValueThird = answer.AnswerValueThird,
                QuestionId = answer.QuestionId,
                Question = QuestionMapper.MapFromDAL(answer.Question),
            };
            return res;

        }
    }
}