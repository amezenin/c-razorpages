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
    public class PersonQuestionsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public PersonQuestionsController( IAppBLL bll)
        {
            _bll = bll;
            
        }

        /// <summary>
        /// Get all PersonQuestion objects
        /// </summary>
        /// <returns>Array of all PersonQuestion with counts of equipment.</returns>
        /// <response code="200">The array of PersonQuestion was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.PersonQuestion>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.PersonQuestion>>> GetPersonQuestions()
        {
            return (await _bll.PersonQuestions.AllForUserAsync(User.GetUserId()))
                .Select(e => PublicApi.v1.Mappers.PersonQuestionMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get PersonQuestion object by ID
        /// </summary>
        /// <returns>PersonQuestion object with details.</returns>
        /// <response code="200">PersonQuestion was successfully retrieved.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.PersonQuestion), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.PersonQuestion>> GetPersonQuestion(int id)
        {
            var personQuestion = PublicApi.v1.Mappers.PersonQuestionMapper
                .MapFromBLL(await _bll.PersonQuestions.FindForUserAsync(id, User.GetUserId()));

            if (personQuestion == null)
            {
                return NotFound();
            }

            return personQuestion;
        }

        /// <summary>
        /// Update PersonQuestion object by ID
        /// </summary>
        /// <returns>PersonQuestion updated object.</returns>
        /// <response code="200">PersonQuestion was successfully updated.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.PersonQuestion), StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonQuestion(int id, PublicApi.v1.DTO.PersonQuestion personQuestion)
        {
            if (id != personQuestion.Id)
            {
                return BadRequest();
            }

            if (!await _bll.PersonQuestions.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            personQuestion.Farmer.AppUserId = User.GetUserId();
            _bll.PersonQuestions.Update(PublicApi.v1.Mappers.PersonQuestionMapper.MapFromExternal( personQuestion));
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        /// <summary>
        /// Post PersonQuestion object 
        /// </summary>
        /// <returns>Created PersonQuestion object.</returns>
        /// <response code="200">PersonQuestion was successfully created.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PublicApi.v1.DTO.PersonQuestion>> PostPersonQuestion(PublicApi.v1.DTO.PersonQuestion personQuestion)
        {
            // check, that the Person being used is really belongs to logged in user
            if (!await _bll.PersonQuestions.BelongsToUserAsync(personQuestion.FarmerId, User.GetUserId()))
            {
                return NotFound();
            }
            
            //await _bll.PersonQuestions.AddAsync(PublicApi.v1.Mappers.PersonQuestionMapper.MapFromExternal(personQuestion));
            //await _bll.SaveChangesAsync();
            
            personQuestion = PublicApi.v1.Mappers.PersonQuestionMapper.MapFromBLL(
                await 
                    _bll.PersonQuestions.AddAsync(PublicApi.v1.Mappers.PersonQuestionMapper.MapFromExternal(personQuestion)));
   
            
            await _bll.SaveChangesAsync();

            personQuestion = PublicApi.v1.Mappers.PersonQuestionMapper.MapFromBLL(
                _bll.PersonQuestions.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.PersonQuestionMapper.MapFromExternal(personQuestion)));


            return CreatedAtAction(
                nameof(GetPersonQuestion), new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = personQuestion.Id
                }, personQuestion);
        }

        /// <summary>
        /// Delete PersonQuestion object by ID
        /// </summary>
        /// <returns>PersonQuestion object deleted.</returns>
        /// <response code="200">PersonQuestion was successfully deleted.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.PersonQuestion), StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonQuestion(int id)
        {
            // check, that the Person being used is really belongs to logged in user
            if (!await _bll.PersonQuestions.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.PersonQuestions.Remove(id);
            await _bll.SaveChangesAsync();


            return NoContent();
        }

       
    }
}
