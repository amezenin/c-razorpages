using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1._0
{
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AnswersController : ControllerBase
    {
        //private readonly AppDbContext _context;
        //private readonly IAnswerRepository _answerRepository;
        //private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;

        public AnswersController( IAppBLL bll)
        {
            _bll = bll;
            
        }

        /// <summary>
        /// Get all Answer objects
        /// </summary>
        /// <returns>Array of all Answers.</returns>
        /// <response code="200">The array of Answers was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.Answer>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Answer>>> GetAnswers()
        {
            //dosnt show data in Aurelia
            return (await _bll.Answers.AllAsync())
                .Select(e => PublicApi.v1.Mappers.AnswerMapper.MapFromBLL(e)).ToList();

        }

        /// <summary>
        /// Get Answer object by ID
        /// </summary>
        /// <returns>Answer object with details.</returns>
        /// <response code="200">Answer was successfully retrieved.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Answer), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Answer>> GetAnswer(int id)
        {
            var answer = PublicApi.v1.Mappers.AnswerMapper
                .MapFromBLL(await _bll.Answers.FindAsync(id));

            if (answer == null)
            {
                return NotFound();
            }

            return answer;
        }

        /// <summary>
        /// Update Answer object by ID
        /// </summary>
        /// <returns>Answer updated object.</returns>
        /// <response code="200">Answer was successfully updated.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Answer), StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswer(int id, PublicApi.v1.DTO.Answer answer)
        {
            if (id != answer.Id)
            {
                return BadRequest();
            }

            
            if (!await _bll.Answers.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.Answers.Update(PublicApi.v1.Mappers.AnswerMapper.MapFromExternal( answer));
            await _bll.SaveChangesAsync();

            return NoContent();


        }

        /// <summary>
        /// Post Answer object 
        /// </summary>
        /// <returns>Created Answer object.</returns>
        /// <response code="200">Answer was successfully created.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BLL.App.DTO.Answer>> PostAnswer(PublicApi.v1.DTO.Answer answer)
        {
            
            answer = PublicApi.v1.Mappers.AnswerMapper.MapFromBLL(
                await 
           _bll.Answers.AddAsync(PublicApi.v1.Mappers.AnswerMapper.MapFromExternal(answer)));

            
            
            await _bll.SaveChangesAsync();

            answer = PublicApi.v1.Mappers.AnswerMapper.MapFromBLL(
                _bll.Answers.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.AnswerMapper.MapFromExternal(answer)));

            return CreatedAtAction(
                nameof(GetAnswer), new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = answer.Id
                }, answer);
        }

        /// <summary>
        /// Delete Answer object by ID
        /// </summary>
        /// <returns>Answer object deleted.</returns>
        /// <response code="200">Answer was successfully deleted.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Answer), StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnswer(int id)
        {
            
            
            _bll.Answers.Remove(id);
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        
    }
}
