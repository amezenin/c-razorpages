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
    public class TanksController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public TanksController( IAppBLL bll)
        {
            _bll = bll;
            
        }

        
        /// <summary>
        /// Get all Tank objects
        /// </summary>
        /// <returns>Array of all Tank with counts of equipment.</returns>
        /// <response code="200">The array of Tank was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.TankDTO>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.TankDTO>>> GetTanks()
        {
           
            return (await _bll.Tanks.GetAllWithBiomassAsync(User.GetUserId()))
                .Select(e => PublicApi.v1.Mappers.TankMapper.MapFromBLL(e)).ToList();

        }
         
        
        

        /// <summary>
        /// Get Tank object by ID
        /// </summary>
        /// <returns>Tank object with details.</returns>
        /// <response code="200">Tank was successfully retrieved.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Tank), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.TankDTO>> GetTank(int id)
        {
            //with user id dont work in aurelia
            //var tank = await _bll.Tanks.FindForUserAsync(id, User.GetUserId());
            var tank = PublicApi.v1.Mappers.TankMapper
                .MapFromBLL(await _bll.Tanks.GetTankWithBiomassAsync(id, User.GetUserId()));
            
            if (tank == null)
            {
                return NotFound();
            }

            return tank;

        }

        /// <summary>
        /// Update Tank object by ID
        /// </summary>
        /// <returns>Tank updated object.</returns>
        /// <response code="200">Tank was successfully updated.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Tank), StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTank(int id, PublicApi.v1.DTO.Tank tank)
        {
            if (id != tank.Id)
            {
                return BadRequest();
            }

            // check, that the Person being used is really belongs to logged in user
            if (!await _bll.Tanks.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
           // tank.Farm.Farmer.AppUserId = User.GetUserId();
            _bll.Tanks.Update(PublicApi.v1.Mappers.TankMapper.MapFromExternal( tank));
            await _bll.SaveChangesAsync();

            return NoContent();
        }
        
       /* 
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Tank), StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<IActionResult> FeedTank(int id, PublicApi.v1.DTO.Tank tank)
        {
            if (id != tank.Id)
            {
                return BadRequest();
            }
            
            

            // check, that the Person being used is really belongs to logged in user
            if (!await _bll.Tanks.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            //tank.Farm.Farmer.AppUserId = User.GetUserId();

            _bll.Tanks.Update(PublicApi.v1.Mappers.TankMapper.MapFromExternal( tank));
            //_bll.Farmers.Update(PublicApi.v1.Mappers.FarmerMapper.MapFromExternal( farmer));
            await _bll.SaveChangesAsync();

            return NoContent();
        }*/

        /// <summary>
        /// Post Tank object 
        /// </summary>
        /// <returns>Created Tank object.</returns>
        /// <response code="200">Tank was successfully created.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PublicApi.v1.DTO.Tank>> PostTank(PublicApi.v1.DTO.Tank tank)
        {
            // check, that the Person being used is really belongs to logged in user
            //may be not wotk Farmer - Farm - Tank
            if (!await _bll.Farms.BelongsToUserAsync(tank.FarmId, User.GetUserId()))
            {
                return NotFound();
            }
            
            //await _bll.Tanks.AddAsync(PublicApi.v1.Mappers.TankMapper.MapFromExternal(tank));
            //await _bll.SaveChangesAsync();
            
            tank = PublicApi.v1.Mappers.TankMapper.MapFromBLL(
                await 
                    _bll.Tanks.AddAsync(PublicApi.v1.Mappers.TankMapper.MapFromExternal(tank)));
   
            await _bll.SaveChangesAsync();

            tank = PublicApi.v1.Mappers.TankMapper.MapFromBLL(
                _bll.Tanks.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.TankMapper.MapFromExternal(tank)));


            return CreatedAtAction(
                nameof(GetTank), new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = tank.Id
                }, tank);
        }

        /// <summary>
        /// Delete Tank object by ID
        /// </summary>
        /// <returns>Tank object deleted.</returns>
        /// <response code="200">Tank was successfully deleted.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Tank), StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTank(int id)
        {
            // check, that the Person being used is really belongs to logged in user
            if (!await _bll.Tanks.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.Tanks.Remove(id);
            await _bll.SaveChangesAsync();
            return NoContent();

        }

      
    }
}
