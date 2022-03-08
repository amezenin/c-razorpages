using System;
using ee.itcollege.anmeze.Contract.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class PersonQuestionMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.PersonQuestion))
            {
                return MapFromDAL((internalDTO.PersonQuestion) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.PersonQuestion))
            {
                return MapFromBLL((externalDTO.PersonQuestion) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.PersonQuestion MapFromDAL(internalDTO.PersonQuestion personQuestion)
        {
            var res = personQuestion == null ? null : new externalDTO.PersonQuestion
            {
                Id = personQuestion.Id,
                FarmerId = personQuestion.FarmerId,
                Farmer = FarmerMapper.MapFromDAL(personQuestion.Farmer),
                QuestionId = personQuestion.QuestionId,
                Question = QuestionMapper.MapFromDAL(personQuestion.Question),
                
            };

            return res;
        }

        public static internalDTO.PersonQuestion MapFromBLL(externalDTO.PersonQuestion personQuestion)
        {
            var res = personQuestion == null ? null : new internalDTO.PersonQuestion
            {
                Id = personQuestion.Id,
                FarmerId = personQuestion.FarmerId,
                Farmer = FarmerMapper.MapFromBLL(personQuestion.Farmer),
                QuestionId = personQuestion.QuestionId,
                Question = QuestionMapper.MapFromBLL(personQuestion.Question),
            };
            return res;
        }

    }
}