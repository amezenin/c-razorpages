using System;
using ee.itcollege.anmeze.Contract.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class QuestionMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Question))
            {
                return MapFromDAL((internalDTO.Question) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Question))
            {
                return MapFromBLL((externalDTO.Question) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Question MapFromDAL(internalDTO.Question question)
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
        
        public static internalDTO.Question MapFromBLL(externalDTO.Question question)
        {
            var res = question == null ? null : new internalDTO.Question()
            {
                Id = question.Id,
                QuestionText = question.QuestionText,
                QuestionGivesScore = question.QuestionGivesScore,
                QuestionMinScore = question.QuestionMinScore,
                QuestionMaxScore = question.QuestionMaxScore
            };

            return res;
        }
    }
}