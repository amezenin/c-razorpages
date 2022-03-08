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
    public class EquipmentsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public EquipmentsController(IAppBLL bll)
        {
            _bll = bll;
            
        }

        /// <summary>
        /// Get all Equipment objects
        /// </summary>
        /// <returns>Array of all Equipments.</returns>
        /// <response code="200">The array of Equipments was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.Equipment>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Equipment>>> GetEquipments()
        {
            //dosnt show data in Aurelia
            return (await _bll.Equipments.AllForUserAsync(User.GetUserId()))
                .Select(e => PublicApi.v1.Mappers.EquipmentMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get Equipment object by ID
        /// </summary>
        /// <returns>Equipment object with details.</returns>
        /// <response code="200">Equipment was successfully retrieved.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Equipment), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Equipment>> GetEquipment(int id)
        {
            var equipment = PublicApi.v1.Mappers.EquipmentMapper
                .MapFromBLL(await _bll.Equipments.FindForUserAsync(id, User.GetUserId()));

            if (equipment == null)
            {
                return NotFound();
            }

            return equipment;
        }

        /// <summary>
        /// Update Equipment object by ID
        /// </summary>
        /// <returns>Equipment updated object.</returns>
        /// <response code="200">Equipment was successfully updated.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Equipment), StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipment(int id, PublicApi.v1.DTO.Equipment equipment)
        {
            if (id != equipment.Id)
            {
                return BadRequest();
            }

            // check, that the Person being used is really belongs to logged in user
            if (!await _bll.Equipments.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            

            _bll.Equipments.Update(PublicApi.v1.Mappers.EquipmentMapper.MapFromExternal( equipment));
            await _bll.SaveChangesAsync();

            return NoContent();


        }

        /// <summary>
        /// Post Equipment object 
        /// </summary>
        /// <returns>Created Equipment object.</returns>
        /// <response code="200">Equipment was successfully created.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PublicApi.v1.DTO.Equipment>> PostEquipment(PublicApi.v1.DTO.Equipment equipment)
        {
            // check, that the Person being used is really belongs to logged in user
            //may be not work Farmer - Farm - Equipment
            if (!await _bll.Farms.BelongsToUserAsync(equipment.FarmId, User.GetUserId()))
            {
                return NotFound();
            }
            
            /*
            await _bll.Equipments.AddAsync(PublicApi.v1.Mappers.EquipmentMapper.MapFromExternal(equipment));
            await _bll.SaveChangesAsync();
            */

            equipment = PublicApi.v1.Mappers.EquipmentMapper.MapFromBLL(
                await 
                    _bll.Equipments.AddAsync(PublicApi.v1.Mappers.EquipmentMapper.MapFromExternal(equipment)));
   
            
            await _bll.SaveChangesAsync();

            equipment = PublicApi.v1.Mappers.EquipmentMapper.MapFromBLL(
                _bll.Equipments.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.EquipmentMapper.MapFromExternal(equipment)));

            return CreatedAtAction(
                nameof(GetEquipment), new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = equipment.Id
                }, equipment);
        }

        /// <summary>
        /// Delete Equipment object by ID
        /// </summary>
        /// <returns>Equipment object deleted.</returns>
        /// <response code="200">Equipment was successfully deleted.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Equipment), StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEquipment(int id)
        {
            // check, that the Person being used is really belongs to logged in user
            if (!await _bll.Equipments.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.Equipments.Remove(id);
            await _bll.SaveChangesAsync();
            return NoContent();

        }

        
    }
}
