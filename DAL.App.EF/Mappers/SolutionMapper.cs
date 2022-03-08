using System;
using ee.itcollege.anmeze.Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class SolutionMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.Solution))
            {
                return MapFromDomain((Domain.Solution) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Solution))
            {
                return MapFromDAL((DAL.App.DTO.Solution) inObject) as TOutObject;
            }

            throw new InvalidCastException("No conversion");
        }


        public static DAL.App.DTO.Solution MapFromDomain(Domain.Solution solution)
        {
            var res = solution == null ? null : new DAL.App.DTO.Solution()
            {
                Id = solution.Id,
                Name = solution.Name,
                SolutionValue = solution.SolutionValue,
                SolutionText = solution.SolutionText,
                QuestionId = solution.QuestionId,
                Question = QuestionMapper.MapFromDomain(solution.Question),
               
            };
            return res;

        }
        
        public static Domain.Solution MapFromDAL(DAL.App.DTO.Solution solution)
        {
            var res = solution == null ? null : new Domain.Solution()
            {
                Id = solution.Id,
                Name = solution.Name,
                SolutionValue = solution.SolutionValue,
                SolutionText = solution.SolutionText,
                QuestionId = solution.QuestionId,
                Question = QuestionMapper.MapFromDAL(solution.Question),
            };
            return res;

        }
    }
}