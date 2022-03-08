using System;
using ee.itcollege.anmeze.Contracts.DAL.Base.Mappers;


namespace DAL.App.EF.Mappers
{
    public class PersonQuestionMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.PersonQuestion))
            {
                return MapFromDomain((Domain.PersonQuestion) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.PersonQuestion))
            {
                return MapFromDAL((DAL.App.DTO.PersonQuestion) inObject) as TOutObject;
            }

            throw new InvalidCastException("No conversion");
        }

        public static DAL.App.DTO.PersonQuestion MapFromDomain(Domain.PersonQuestion personQuestion)
        {
            
            var res = personQuestion == null ? null : new DAL.App.DTO.PersonQuestion
            {
                Id = personQuestion.Id,
                FarmerId = personQuestion.FarmerId,
                Farmer = FarmerMapper.MapFromDomain(personQuestion.Farmer),
                QuestionId = personQuestion.QuestionId,
                Question = QuestionMapper.MapFromDomain(personQuestion.Question),
            };

            return res;
        }

        public static Domain.PersonQuestion MapFromDAL(DAL.App.DTO.PersonQuestion personQuestion)
        {
            var res = personQuestion == null ? null : new Domain.PersonQuestion
            {
                Id = personQuestion.Id,
                FarmerId = personQuestion.FarmerId,
                Farmer = FarmerMapper.MapFromDAL(personQuestion.Farmer),
                QuestionId = personQuestion.QuestionId,
                Question = QuestionMapper.MapFromDAL(personQuestion.Question),
            };

            
            return res;
        }
    }
}