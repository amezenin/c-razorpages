using System;
using ee.itcollege.anmeze.Contract.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class SolutionMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Solution))
            {
                return MapFromDAL((internalDTO.Solution) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Solution))
            {
                return MapFromBLL((externalDTO.Solution) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Solution MapFromDAL(internalDTO.Solution solution)
        {
            var res = solution == null ? null : new externalDTO.Solution()
            {
                Id = solution.Id,
                Name = solution.Name,
                SolutionText = solution.SolutionText,
                SolutionValue = solution.SolutionValue,
                QuestionId = solution.QuestionId,
                Question = QuestionMapper.MapFromDAL(solution.Question),
            };
            return res;
        }
        
        public static internalDTO.Solution MapFromBLL(externalDTO.Solution solution)
        {
            var res = solution == null ? null : new internalDTO.Solution()
            {
                Id = solution.Id,
                Name = solution.Name,
                SolutionText = solution.SolutionText,
                SolutionValue = solution.SolutionValue,
                QuestionId = solution.QuestionId,
                Question = QuestionMapper.MapFromBLL(solution.Question),
            };
            return res;
        }
        
        
    }
}