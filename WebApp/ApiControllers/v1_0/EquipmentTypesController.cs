using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
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
    public class EquipmentTypesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public EquipmentTypesController( IAppBLL bll)
        {
            _bll = bll;
            
        }

        /// <summary>
        /// Get all EquipmentType objects
        /// </summary>
        /// <returns>Array of all EquipmentType with counts of equipment.</returns>
        /// <response code="200">The array of EquipmentType was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.EquipmentTypeDTO>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.EquipmentTypeDTO>>> GetEquipmentTypes()
        {
           // return await _bll.EquipmentTypes.GetAllWithEquipmentTypeCountAsync();
           return (await _bll.EquipmentTypes.GetAllWithEquipmentTypeCountAsync())
               .Select(e => PublicApi.v1.Mappers.EquipmentTypeMapper.MapFromBLL(e)).ToList();

           
        }

        /// <summary>
        /// Get EquipmentType object by ID
        /// </summary>
        /// <returns>EquipmentType object with details.</returns>
        /// <response code="200">EquipmentType was successfully retrieved.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.EquipmentType), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.EquipmentType>> GetEquipmentType(int id)
        {
            //var equipmentType = await _bll.EquipmentTypes.FindAsync(id);
            
            var equipmentType = PublicApi.v1.Mappers.EquipmentTypeMapper.MapFromBLL( await _bll.EquipmentTypes.FindAsync(id));

            if (equipmentType == null)
            {
                return NotFound();
            }

            return equipmentType;
        }

        /// <summary>
        /// Update EquipmentType object by ID
        /// </summary>
        /// <returns>EquipmentType updated object.</returns>
        /// <response code="200">EquipmentType was successfully updated.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.EquipmentType), StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentType(int id, PublicApi.v1.DTO.EquipmentType equipmentType)
        {
            if (id != equipmentType.Id)
            {
                return BadRequest();
            }

           // _bll.EquipmentTypes.Update(equipmentType);
           
           _bll.EquipmentTypes.Update(PublicApi.v1.Mappers.EquipmentTypeMapper.MapFromExternal( equipmentType));
            await _bll.SaveChangesAsync();

          

            return NoContent();
        }

        /// <summary>
        /// Post EquipmentType object 
        /// </summary>
        /// <returns>Created EquipmentType object.</returns>
        /// <response code="200">EquipmentType was successfully created.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PublicApi.v1.DTO.EquipmentType>> PostEquipmentType(PublicApi.v1.DTO.EquipmentType equipmentType)
        {
            //await _bll.EquipmentTypes.AddAsync(equipmentType);
            
           // await _bll.EquipmentTypes.AddAsync(PublicApi.v1.Mappers.EquipmentTypeMapper.MapFromExternal(equipmentType));
           // await _bll.SaveChangesAsync();

            equipmentType = PublicApi.v1.Mappers.EquipmentTypeMapper.MapFromBLL(
                await 
                    _bll.EquipmentTypes.AddAsync(PublicApi.v1.Mappers.EquipmentTypeMapper.MapFromExternal(equipmentType)));
   
            
            await _bll.SaveChangesAsync();

            equipmentType = PublicApi.v1.Mappers.EquipmentTypeMapper.MapFromBLL(
                _bll.EquipmentTypes.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.EquipmentTypeMapper.MapFromExternal(equipmentType)));
            
            
            //for swagger
            return CreatedAtAction(
                nameof(GetEquipmentType), new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = equipmentType.Id
                }, equipmentType);

        }

        /// <summary>
        /// Delete EquipmentType object by ID
        /// </summary>
        /// <returns>EquipmentType object deleted.</returns>
        /// <response code="200">EquipmentType was successfully deleted.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.EquipmentType), StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.EquipmentType>> DeleteEquipmentType(int id)
        {
            var equipmentType = await _bll.EquipmentTypes.FindAsync(id);
            if (equipmentType == null)
            {
                return NotFound();
            }

            _bll.EquipmentTypes.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        
    }
}
