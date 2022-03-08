using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;


namespace PublicApi.v1.Mappers
{
    public class AnsweredQuestionMapper
    {
       
            public TOutObject Map<TOutObject>(object inObject)
                where TOutObject : class
            {
                if (typeof(TOutObject) == typeof(externalDTO.AnsweredQuestion))
                {
                    // map internalDTO to externalDTO
                    return MapFromBLL((internalDTO.AnsweredQuestion) inObject) as TOutObject;
                }

                if (typeof(TOutObject) == typeof(internalDTO.AnsweredQuestion))
                {
                    // map externalDTO to internalDTO
                    return MapFromExternal((externalDTO.AnsweredQuestion) inObject) as TOutObject;
                }

                throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");

            }

            public static externalDTO.AnsweredQuestion MapFromBLL(internalDTO.AnsweredQuestion answeredQuestion)
            {
                var res = answeredQuestion == null ? null : new externalDTO.AnsweredQuestion()
                {
                    Id = answeredQuestion.Id,
                    FarmerId = answeredQuestion.FarmerId,
                    Farmer = FarmerMapper.MapFromBLL(answeredQuestion.Farmer),
                    QuestionId = answeredQuestion.QuestionId,
                    Question = QuestionMapper.MapFromBLL(answeredQuestion.Question),
                };

                return res;
            }
        
            public static internalDTO.AnsweredQuestion MapFromExternal(externalDTO.AnsweredQuestion answeredQuestion)
            {
                var res = answeredQuestion == null ? null : new internalDTO.AnsweredQuestion()
                {
                    Id = answeredQuestion.Id,
                    FarmerId = answeredQuestion.FarmerId,
                    Farmer = FarmerMapper.MapFromExternal(answeredQuestion.Farmer),
                    QuestionId = answeredQuestion.QuestionId,
                    Question = QuestionMapper.MapFromExternal(answeredQuestion.Question),
                };

                return res;
            }

    }
}