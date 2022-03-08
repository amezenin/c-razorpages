using System;
using ee.itcollege.anmeze.Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class QuestionMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.Question))
            {
                return MapFromDomain((Domain.Question) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Question))
            {
                return MapFromDAL((DAL.App.DTO.Question) inObject) as TOutObject;
            }

            throw new InvalidCastException("No conversion");
        }


        public static DAL.App.DTO.Question MapFromDomain(Domain.Question question)
        {
            var res = question == null ? null : new DAL.App.DTO.Question()
            {
                Id = question.Id,
                QuestionText = question.QuestionText,
                QuestionGivesScore = question.QuestionGivesScore,
                QuestionMinScore = question.QuestionMinScore,
                QuestionMaxScore = question.QuestionMaxScore,
               
            };

            return res;
        }
        
        public static Domain.Question MapFromDAL(DAL.App.DTO.Question question)
        {
            var res = question == null ? null : new Domain.Question()
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