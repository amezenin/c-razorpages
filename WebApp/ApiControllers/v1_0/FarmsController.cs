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
    public class FarmsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public FarmsController( IAppBLL bll)
        {
            _bll = bll;
            
        }

        /// <summary>
        /// Get all Farm objects
        /// </summary>
        /// <returns>Array of all Farm with counts of equipment.</returns>
        /// <response code="200">The array of Farm was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.Farm>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Farm>>> GetFarms()
        {
            //dosnt show data in Aurelia
            
            //return await _bll.Farms.AllForUserAsync(User.GetUserId());
            return (await _bll.Farms.AllForUserAsync(User.GetUserId()))
                .Select(e => PublicApi.v1.Mappers.FarmMapper.MapFromBLL(e)).ToList();
            
        }

        /// <summary>
        /// Get Farm object by ID
        /// </summary>
        /// <returns>Farm object with details.</returns>
        /// <response code="200">Farm was successfully retrieved.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Farm), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Farm>> GetFarm(int id)
        {
            var farm = PublicApi.v1.Mappers.FarmMapper.MapFromBLL(await _bll.Farms.FindForUserAsync(id, User.GetUserId()));

            if (farm == null)
            {
                return NotFound();
            }

            return farm;
        }

        /// <summary>
        /// Update Farm object by ID
        /// </summary>
        /// <returns>Farm updated object.</returns>
        /// <response code="200">Farm was successfully updated.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Farm), StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarm(int id, PublicApi.v1.DTO.Farm farm)
        {
            if (id != farm.Id)
            {
                return BadRequest();
            }

            if (!await _bll.Farms.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            farm.Farmer.AppUserId = User.GetUserId();
            
            _bll.Farms.Update(PublicApi.v1.Mappers.FarmMapper.MapFromExternal( farm));
            await _bll.SaveChangesAsync();

            return NoContent();


        }

        /// <summary>
        /// Post Farm object 
        /// </summary>
        /// <returns>Created Farm object.</returns>
        /// <response code="200">Farm was successfully created.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PublicApi.v1.DTO.Farm>> PostFarm(PublicApi.v1.DTO.Farm farm)
        {
            

            // check, that the Person being used is really belongs to logged in user
            if (!await _bll.Farmers.BelongsToUserAsync(farm.FarmerId, User.GetUserId()))
            {
                return NotFound();
            }
            
            //await _bll.Farms.AddAsync(PublicApi.v1.Mappers.FarmMapper.MapFromExternal(farm));
            //await _bll.SaveChangesAsync();
            
            farm = PublicApi.v1.Mappers.FarmMapper.MapFromBLL(
                await 
                    _bll.Farms.AddAsync(PublicApi.v1.Mappers.FarmMapper.MapFromExternal(farm)));
   
            
            await _bll.SaveChangesAsync();

            farm = PublicApi.v1.Mappers.FarmMapper.MapFromBLL(
                _bll.Farms.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.FarmMapper.MapFromExternal(farm)));

            return CreatedAtAction(
                nameof(GetFarm), new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = farm.Id
                }, farm);

        }

        /// <summary>
        /// Delete Farm object by ID
        /// </summary>
        /// <returns>Farm object deleted.</returns>
        /// <response code="200">Farm was successfully deleted.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Farm), StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFarm(int id)
        {
            // check, that the Person being used is really belongs to logged in user
            if (!await _bll.Farms.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.Farms.Remove(id);
            await _bll.SaveChangesAsync();
            return NoContent();

        }

        
    }
}
