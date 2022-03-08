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
    public class AnsweredQuestionsController : ControllerBase
    {
        //private readonly AppDbContext _context;
        //private readonly IAnsweredQuestionsRepository _answeredQuestionsRepository;

        private readonly IAppBLL _bll;

        public AnsweredQuestionsController( IAppBLL bll)
        {
            _bll = bll;
            //_context = context;
            //_answeredQuestionsRepository = answeredQuestionsRepository;
            
        }

        /// <summary>
        /// Get all AnsweredQuestion objects
        /// </summary>
        /// <returns>Array of all AnsweredQuestions.</returns>
        /// <response code="200">The array of AnsweredQuestions was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.AnsweredQuestion>), StatusCodes.Status200OK)]
        [HttpGet]  
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.AnsweredQuestion>>> GetAnsweredQuestions()
        {
           /* return (await _bll.AnsweredQuestions.GetAllWithContactCountAsync())
                .Select(e => PublicApi.v1.Mappers.AnsweredQuestionMapper.MapFromBLL(e)).ToList();*/
           return (await _bll.AnsweredQuestions.AllForUserAsync(User.GetUserId()))
               .Select(e => PublicApi.v1.Mappers.AnsweredQuestionMapper.MapFromBLL(e)).ToList();


        }

        /// <summary>
        /// Get AnsweredQuestion object by ID
        /// </summary>
        /// <returns>AnsweredQuestions object with details.</returns>
        /// <response code="200">AnsweredQuestions was successfully retrieved.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.AnsweredQuestion), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.AnsweredQuestion>> GetAnsweredQuestion(int id)
        {
            var answeredQuestion = PublicApi.v1.Mappers.AnsweredQuestionMapper
                .MapFromBLL(await _bll.AnsweredQuestions.FindForUserAsync(id, User.GetUserId()));

            if (answeredQuestion == null)
            {
                return NotFound();
            }

            return answeredQuestion;
        }

        /// <summary>
        /// Update AnsweredQuestion object by ID
        /// </summary>
        /// <returns>AnsweredQuestion updated object.</returns>
        /// <response code="200">AnsweredQuestion was successfully updated.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.AnsweredQuestion), StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnsweredQuestion(int id, PublicApi.v1.DTO.AnsweredQuestion answeredQuestion)
        {
            if (id != answeredQuestion.Id)
            {
                return BadRequest();
            }

            if (!await _bll.AnsweredQuestions.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
           // answeredQuestion.Farmer.AppUserId = User.GetUserId();
            _bll.AnsweredQuestions.Update(PublicApi.v1.Mappers.AnsweredQuestionMapper.MapFromExternal( answeredQuestion));
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        /// <summary>
        /// Post AnsweredQuestion object 
        /// </summary>
        /// <returns>Created AnsweredQuestion object.</returns>
        /// <response code="200">AnsweredQuestion was successfully created.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PublicApi.v1.DTO.AnsweredQuestion>> PostAnsweredQuestion(PublicApi.v1.DTO.AnsweredQuestion answeredQuestion)
        {
            // check, that the Person being used is really belongs to logged in user
            if (!await _bll.AnsweredQuestions.BelongsToUserAsync(answeredQuestion.FarmerId, User.GetUserId()))
            {
                return NotFound();
            }
            
            answeredQuestion = PublicApi.v1.Mappers.AnsweredQuestionMapper.MapFromBLL(
            await _bll.AnsweredQuestions.AddAsync(PublicApi.v1.Mappers.AnsweredQuestionMapper.MapFromExternal(answeredQuestion)));
            
            await _bll.SaveChangesAsync();
            
            answeredQuestion = PublicApi.v1.Mappers.AnsweredQuestionMapper.MapFromBLL(
                _bll.AnsweredQuestions.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.AnsweredQuestionMapper.MapFromExternal(answeredQuestion)));


            return CreatedAtAction("GetAnsweredQuestion", new { id = answeredQuestion.Id }, answeredQuestion);
        }

        /// <summary>
        /// Delete AnsweredQuestion object by ID
        /// </summary>
        /// <returns>AnsweredQuestion object deleted.</returns>
        /// <response code="200">AnsweredQuestion was successfully deleted.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.EquipmentType), StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnsweredQuestion(int id)
        {
            // check, that the Person being used is really belongs to logged in user
            if (!await _bll.AnsweredQuestions.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.AnsweredQuestions.Remove(id);
            await _bll.SaveChangesAsync();


            return NoContent();
        }

       
    }
}
