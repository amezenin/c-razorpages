using System;
using ee.itcollege.anmeze.Contract.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class AnswerMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Answer))
            {
                return MapFromDAL((internalDTO.Answer) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Answer))
            {
                return MapFromBLL((externalDTO.Answer) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Answer MapFromDAL(internalDTO.Answer answer)
        {
            var res = answer == null ? null : new externalDTO.Answer()
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
        
        public static internalDTO.Answer MapFromBLL(externalDTO.Answer answer)
        {
            var res = answer == null ? null : new internalDTO.Answer()
            {
                Id = answer.Id,
                AnswerValueFirst = answer.AnswerValueFirst,
                AnswerValueSecond = answer.AnswerValueSecond,
                AnswerValueThird = answer.AnswerValueThird,
                QuestionId = answer.QuestionId,
                Question = QuestionMapper.MapFromBLL(answer.Question),
            };
            return res;
        }
    }
}