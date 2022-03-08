using System;
using externalDTO = PublicApi.v2.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v2.Mappers
{
    public class SolutionMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Solution))
            {
                // map internalDTO to externalDTO
                return MapFromBLL((internalDTO.Solution) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Solution))
            {
                // map externalDTO to internalDTO
                return MapFromExternal((externalDTO.Solution) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");

        }

        public static externalDTO.Solution MapFromBLL(internalDTO.Solution solution)
        {
            var res = solution == null ? null : new externalDTO.Solution()
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
        
        public static internalDTO.Solution MapFromExternal(externalDTO.Solution solution)
        {
            var res = solution == null ? null : new internalDTO.Solution()
            {
                Id = solution.Id,
                Name = solution.Name,
                SolutionText = solution.SolutionText,
                SolutionValue = solution.SolutionValue,
                QuestionId = solution.QuestionId,
                Question = QuestionMapper.MapFromExternal(solution.Question),
            };

            return res;
        }
    }
}