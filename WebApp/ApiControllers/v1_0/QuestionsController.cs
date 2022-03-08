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
    public class QuestionsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public QuestionsController( IAppBLL bll)
        {
            _bll = bll;
            
        }

        /// <summary>
        /// Get all Question objects
        /// </summary>
        /// <returns>Array of all Question with counts of equipment.</returns>
        /// <response code="200">The array of Question was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.Question>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Question>>> GetQuestions()
        {
            return (await _bll.Questions.AllForUserAsync(User.GetUserId()))
                .Select(e => PublicApi.v1.Mappers.QuestionMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get Question object by ID
        /// </summary>
        /// <returns>Question object with details.</returns>
        /// <response code="200">Question was successfully retrieved.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Question), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Question>> GetQuestion(int id)
        {
            var question = PublicApi.v1.Mappers.QuestionMapper
                .MapFromBLL(await _bll.Questions.FindForUserAsync(id, User.GetUserId()));

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        /// <summary>
        /// Update Question object by ID
        /// </summary>
        /// <returns>Question updated object.</returns>
        /// <response code="200">Question was successfully updated.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Question), StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, PublicApi.v1.DTO.Question question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            if (!await _bll.Questions.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            
            _bll.Questions.Update(PublicApi.v1.Mappers.QuestionMapper.MapFromExternal( question));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Post Question object 
        /// </summary>
        /// <returns>Created Question object.</returns>
        /// <response code="200">Question was successfully created.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PublicApi.v1.DTO.Question>> PostQuestion(PublicApi.v1.DTO.Question question)
        {
            //await _bll.Questions.AddAsync(PublicApi.v1.Mappers.QuestionMapper.MapFromExternal(question));
            //await _bll.SaveChangesAsync();
            
            question = PublicApi.v1.Mappers.QuestionMapper.MapFromBLL(
                await 
                    _bll.Questions.AddAsync(PublicApi.v1.Mappers.QuestionMapper.MapFromExternal(question)));
   
            
            await _bll.SaveChangesAsync();

            question = PublicApi.v1.Mappers.QuestionMapper.MapFromBLL(
                _bll.Questions.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.QuestionMapper.MapFromExternal(question)));

            return CreatedAtAction(
                nameof(GetQuestion), new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = question.Id
                }, question);
        }

        /// <summary>
        /// Delete Question object by ID
        /// </summary>
        /// <returns>Question object deleted.</returns>
        /// <response code="200">Question was successfully deleted.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.Question), StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuestion(int id)
        {
            _bll.Questions.Remove(id);
            await _bll.SaveChangesAsync();


            return NoContent();

        }

        
    }
}
