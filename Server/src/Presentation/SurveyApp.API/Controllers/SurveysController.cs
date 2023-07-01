using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Application.Dtos.Requests;
using SurveyApp.Application.Interfaces.Services;
using System.Security.Claims;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        private Guid UserId => Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

        public SurveysController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var survey = await _surveyService.GetSurveyByIdAsync(id);

            if(survey is  null) { 
                return NotFound();
            }
            return Ok(survey);
        }
        
        [HttpGet("surveyForUpdate/{id}")]
        public async Task<IActionResult> GetSurveyForupdate(Guid id)
        {
            var survey = await _surveyService.GetSurveyForUpdateByIdAsync(id);

            if(survey is  null) { 
                return NotFound();
            }
            return Ok(survey);
        }

        [HttpGet("GetCreatedSurveys")]
        [Authorize]
        public async Task<IActionResult> GetCreatedSurveys()
        {
            var survey = await _surveyService.GetSurveysByUserIdAsync(UserId);

            if(survey is  null) { 
                return NotFound();
            }
            return Ok(survey);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CreateSurveyRequest request)
        {
            request.CreatedById = UserId;
            var id = await _surveyService.AddAsync(request);
            return Created($"/surveys/{id}",id);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(Guid surveyId)
        {            
            await _surveyService.DeleteAsync(surveyId);
            return NoContent();
        }
    }
}
