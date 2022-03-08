using System;
using externalDTO = PublicApi.v2.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v2.Mappers
{
    public class AnswerMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
                where TOutObject : class
            {
                if (typeof(TOutObject) == typeof(externalDTO.Answer))
                {
                    // map internalDTO to externalDTO
                    return MapFromBLL((internalDTO.Answer) inObject) as TOutObject;
                }

                if (typeof(TOutObject) == typeof(internalDTO.Answer))
                {
                    // map externalDTO to internalDTO
                    return MapFromExternal((externalDTO.Answer) inObject) as TOutObject;
                }

                throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");

            }

            public static externalDTO.Answer MapFromBLL(internalDTO.Answer answer)
            {
                var res = answer == null ? null : new externalDTO.Answer()
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
        
            public static internalDTO.Answer MapFromExternal(externalDTO.Answer answer)
            {
                var res = answer == null ? null : new internalDTO.Answer()
                {
                    Id = answer.Id,
                    AnswerValueFirst = answer.AnswerValueFirst,
                    AnswerValueSecond = answer.AnswerValueSecond,
                    AnswerValueThird = answer.AnswerValueThird,
                    QuestionId = answer.QuestionId,
                    Question = QuestionMapper.MapFromExternal(answer.Question),
                };

                return res;
            }
    }
}