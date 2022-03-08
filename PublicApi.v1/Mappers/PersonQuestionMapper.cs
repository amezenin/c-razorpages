using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class PersonQuestionMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
                where TOutObject : class
            {
                if (typeof(TOutObject) == typeof(externalDTO.PersonQuestion))
                {
                    // map internalDTO to externalDTO
                    return MapFromBLL((internalDTO.PersonQuestion) inObject) as TOutObject;
                }

                if (typeof(TOutObject) == typeof(internalDTO.PersonQuestion))
                {
                    // map externalDTO to internalDTO
                    return MapFromExternal((externalDTO.PersonQuestion) inObject) as TOutObject;
                }

                throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");

            }

            public static externalDTO.PersonQuestion MapFromBLL(internalDTO.PersonQuestion personQuestion)
            {
                var res = personQuestion == null ? null : new externalDTO.PersonQuestion()
                {
                    Id = personQuestion.Id,
                    FarmerId = personQuestion.FarmerId,
                    Farmer = FarmerMapper.MapFromBLL(personQuestion.Farmer),
                    QuestionId = personQuestion.QuestionId,
                    Question = QuestionMapper.MapFromBLL(personQuestion.Question),
                };

                return res;
            }
        
            public static internalDTO.PersonQuestion MapFromExternal(externalDTO.PersonQuestion personQuestion)
            {
                var res = personQuestion == null ? null : new internalDTO.PersonQuestion()
                {
                    Id = personQuestion.Id,
                    FarmerId = personQuestion.FarmerId,
                    Farmer = FarmerMapper.MapFromExternal(personQuestion.Farmer),
                    QuestionId = personQuestion.QuestionId,
                    Question = QuestionMapper.MapFromExternal(personQuestion.Question),
                };

                return res;
            }
    }
}