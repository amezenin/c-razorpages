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
    public class FarmersController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public FarmersController(IAppBLL bll)
        {
            _bll = bll;
            
        }

        /// <summary>
        /// Get all Farmer objects
        /// </summary>
        /// <returns>Array of all Farmer with counts of equipment.</returns>
        /// <response code="200">The array of Farmer was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.Farmer>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Farmer>>> GetFarmers()
        {
            //dosnt show data in Aurelia
            //return await _bll.Farmers.AllForUserAsync(User.GetUserId());
            //return await _bll.Farmers.AllAsync();
            
            //didnt show data in Aurelia
            return (await _bll.Farmers.AllForUserAsync(User.GetUserId()))
                .Select(e => PublicApi.v1.Mappers.FarmerMapper.MapFromBLL(e)).ToList();

        }

        /// <summary>
        /// Get Farmer object by ID
        /// </summary>
        /// <returns>Farmer object with details.</returns>
        /// <response code="200">Farmer was successfully retrieved.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Farmer), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Farmer>> GetFarmer(int id)
        {
            //var farmer = await _bll.Farmers.FindForUserAsync(id, User.GetUserId());
            
            var farmer = PublicApi.v1.Mappers.FarmerMapper.MapFromBLL(await _bll.Farmers.FindForUserAsync(id, User.GetUserId()));

            if (farmer == null)
            {
                return NotFound();
            }

            return farmer;
        }

        /// <summary>
        /// Update Farmer object by ID
        /// </summary>
        /// <returns>Farmer updated object.</returns>
        /// <response code="200">Farmer was successfully updated.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Farmer), StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarmer(int id, PublicApi.v1.DTO.Farmer farmer)
        {
            if (id != farmer.Id)
            {
                return BadRequest();
            }

            // check for the ownership - is this Person record really belonging to logged in user.
            if (!await _bll.Farmers.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            farmer.AppUserId = User.GetUserId();
            
            _bll.Farmers.Update(PublicApi.v1.Mappers.FarmerMapper.MapFromExternal( farmer));
            await _bll.SaveChangesAsync();


            return NoContent();


        }

        /// <summary>
        /// Post Farmer object 
        /// </summary>
        /// <returns>Created Farmer object.</returns>
        /// <response code="200">Farmer was successfully created.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PublicApi.v1.DTO.Farmer>> PostFarmer(PublicApi.v1.DTO.Farmer farmer)
        {
            farmer.AppUserId = User.GetUserId();
            
            //await _bll.Farmers.AddAsync(PublicApi.v1.Mappers.FarmerMapper.MapFromExternal(farmer));
            //await _bll.SaveChangesAsync();
            
            farmer = PublicApi.v1.Mappers.FarmerMapper.MapFromBLL(
                await 
                    _bll.Farmers.AddAsync(PublicApi.v1.Mappers.FarmerMapper.MapFromExternal(farmer)));
   
            
            await _bll.SaveChangesAsync();

            farmer = PublicApi.v1.Mappers.FarmerMapper.MapFromBLL(
                _bll.Farmers.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.FarmerMapper.MapFromExternal(farmer)));


            return CreatedAtAction(
                nameof(GetFarmer), new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = farmer.Id
                }, farmer);
        }

        /// <summary>
        /// Delete Farmer object by ID
        /// </summary>
        /// <returns>Farmer object deleted.</returns>
        /// <response code="200">Farmer was successfully deleted.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Farmer), StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFarmer(int id)
        {
            // check for the ownership - is this Person record really belonging to logged in user.
            if (!await _bll.Farmers.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.Farmers.Remove(id);
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        
    }
}
