using System;
using externalDTO = PublicApi.v2.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v2.Mappers
{
    public class QuestionMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
                where TOutObject : class
            {
                if (typeof(TOutObject) == typeof(externalDTO.Question))
                {
                    // map internalDTO to externalDTO
                    return MapFromBLL((internalDTO.Question) inObject) as TOutObject;
                }

                if (typeof(TOutObject) == typeof(internalDTO.Question))
                {
                    // map externalDTO to internalDTO
                    return MapFromExternal((externalDTO.Question) inObject) as TOutObject;
                }

                throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");

            }

            public static externalDTO.Question MapFromBLL(internalDTO.Question question)
            {
                var res = question == null ? null : new externalDTO.Question()
                {
                    Id = question.Id,
                    QuestionText = question.QuestionText,
                    QuestionGivesScore = question.QuestionGivesScore,
                    QuestionMinScore = question.QuestionMinScore,
                    QuestionMaxScore = question.QuestionMaxScore,
                };

                return res;
            }
        
            public static internalDTO.Question MapFromExternal(externalDTO.Question question)
            {
                var res = question == null ? null : new internalDTO.Question()
                {
                    Id = question.Id,
                    QuestionText = question.QuestionText,
                    QuestionGivesScore = question.QuestionGivesScore,
                    QuestionMinScore = question.QuestionMinScore,
                    QuestionMaxScore = question.QuestionMaxScore,
                };

                return res;
            }
    }
}