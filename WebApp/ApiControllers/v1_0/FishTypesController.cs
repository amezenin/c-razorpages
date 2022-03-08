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
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FishTypesController : ControllerBase
    {
        //private readonly AppDbContext _context;
        //private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;

        public FishTypesController( IAppBLL bll)
        {
            _bll = bll;
            
            // _context = context;
        }

        /// <summary>
        /// Get all FishType objects
        /// </summary>
        /// <returns>Array of all FishType with counts of equipment.</returns>
        /// <response code="200">The array of FishType was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.FishTypeDTO>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.FishTypeDTO>>> GetFishTypes()
        {
             
              /*var res = new List<FishTypeDTO>();
              var fishTypes = await _uow.FishTypes.AllAsync();
              foreach (var fishType in fishTypes)
              {
                  res.Add(new FishTypeDTO()
                  {
                      Id = fishType.Id,
                      Species = fishType.Species,
                      MaxTemp = fishType.MaxTemp,
                      MinTemp = fishType.MinTemp,
                      MaxNh = fishType.MaxNh,
                      MaxNo = fishType.MaxNo,
                      MaxDensity = fishType.MaxDensity,
                      TankCount = fishType.Tanks.Count
                  });
              }*/
              return (await _bll.FishTypes.GetAllWithFishTypeCountAsync())
                  .Select(e => PublicApi.v1.Mappers.FishTypeMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get FishType object by ID
        /// </summary>
        /// <returns>FishType object with details.</returns>
        /// <response code="200">FishType was successfully retrieved.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.FishType), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.FishType>> GetFishType(int id)
        {
            var fishType = PublicApi.v1.Mappers.FishTypeMapper.MapFromBLL(await _bll.FishTypes.FindForUserAsync(id, User.GetUserId()));

            if (fishType == null)
            {
                return NotFound();
            }

            return fishType;
        }

        /// <summary>
        /// Update FishType object by ID
        /// </summary>
        /// <returns>FishType updated object.</returns>
        /// <response code="200">FishType was successfully updated.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.FishType), StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFishType(int id, PublicApi.v1.DTO.FishType fishType)
        {
            if (id != fishType.Id)
            {
                return BadRequest();
            }

            _bll.FishTypes.Update(PublicApi.v1.Mappers.FishTypeMapper.MapFromExternal( fishType));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Post FishType object 
        /// </summary>
        /// <returns>Created FishType object.</returns>
        /// <response code="200">FishType was successfully created.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PublicApi.v1.DTO.FishType>> PostFishType(PublicApi.v1.DTO.FishType fishType)
        {
            //await _bll.FishTypes.AddAsync(PublicApi.v1.Mappers.FishTypeMapper.MapFromExternal(fishType));
            //await _bll.SaveChangesAsync();
            
            fishType = PublicApi.v1.Mappers.FishTypeMapper.MapFromBLL(
                await 
                    _bll.FishTypes.AddAsync(PublicApi.v1.Mappers.FishTypeMapper.MapFromExternal(fishType)));
   
            
            await _bll.SaveChangesAsync();

            fishType = PublicApi.v1.Mappers.FishTypeMapper.MapFromBLL(
                _bll.FishTypes.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.FishTypeMapper.MapFromExternal(fishType)));

            return CreatedAtAction(
                nameof(GetFishType), new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = fishType.Id
                }, fishType);
        }

        /// <summary>
        /// Delete FishType object by ID
        /// </summary>
        /// <returns>FishType object deleted.</returns>
        /// <response code="200">FishType was successfully deleted.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Farm), StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.FishType>> DeleteFishType(int id)
        {
            var fishType = await _bll.FishTypes.FindAsync(id);
            if (fishType == null)
            {
                return NotFound();
            }

            _bll.FishTypes.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();;
        }

    
    }
}
