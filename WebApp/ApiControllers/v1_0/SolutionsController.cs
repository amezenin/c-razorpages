using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SolutionsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SolutionsController( IAppBLL bll)
        {
            _bll = bll;
            
        }

        /// <summary>
        /// Get all Solution objects
        /// </summary>
        /// <returns>Array of all Solution with counts of equipment.</returns>
        /// <response code="200">The array of Solution was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.Solution>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Solution>>> GetSolutions()
        {
            return (await _bll.Solutions.AllAsync())
                .Select(e => PublicApi.v1.Mappers.SolutionMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get Solution object by ID
        /// </summary>
        /// <returns>Solution object with details.</returns>
        /// <response code="200">Solution was successfully retrieved.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Solution), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Solution>> GetSolution(int id)
        {
            var solution = PublicApi.v1.Mappers.SolutionMapper
                .MapFromBLL(await _bll.Solutions.FindForUserAsync(id, User.GetUserId()));

            if (solution == null)
            {
                return NotFound();
            }

            return solution;
        }

        /// <summary>
        /// Update Solution object by ID
        /// </summary>
        /// <returns>Solution updated object.</returns>
        /// <response code="200">Solution was successfully updated.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Solution), StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolution(int id, PublicApi.v1.DTO.Solution solution)
        {
            if (id != solution.Id)
            {
                return BadRequest();
            }         

            
            if (!await _bll.Solutions.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.Solutions.Update(PublicApi.v1.Mappers.SolutionMapper.MapFromExternal( solution));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Post Solution object 
        /// </summary>
        /// <returns>Created Solution object.</returns>
        /// <response code="200">Solution was successfully created.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PublicApi.v1.DTO.Solution>> PostSolution(PublicApi.v1.DTO.Solution solution)
        {
            //await _bll.Solutions.AddAsync(PublicApi.v1.Mappers.SolutionMapper.MapFromExternal(solution));
            //await _bll.SaveChangesAsync();
            
            solution = PublicApi.v1.Mappers.SolutionMapper.MapFromBLL(
                await 
                    _bll.Solutions.AddAsync(PublicApi.v1.Mappers.SolutionMapper.MapFromExternal(solution)));
   
            await _bll.SaveChangesAsync();

            solution = PublicApi.v1.Mappers.SolutionMapper.MapFromBLL(
                _bll.Solutions.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.SolutionMapper.MapFromExternal(solution)));

            return CreatedAtAction(
                nameof(GetSolution), new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = solution.Id
                }, solution);
        }

        /// <summary>
        /// Delete Solution object by ID
        /// </summary>
        /// <returns>Solution object deleted.</returns>
        /// <response code="200">Solution was successfully deleted.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Solution), StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSolution(int id)
        {
            _bll.Solutions.Remove(id);
            await _bll.SaveChangesAsync();


            return NoContent();

            
        }

        
    }
}
