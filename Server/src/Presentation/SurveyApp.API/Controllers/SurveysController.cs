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
    [Authorize]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        private Guid UserId => Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

        public SurveysController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var survey = await _surveyService.GetSurveysAsync();

            if(survey is  null) { 
                return NotFound();
            }
            return Ok(survey);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
        {
            var survey = await _surveyService.GetSurveyByIdAsync(id);

            if(survey is  null) { 
                return NotFound();
            }
            return Ok(survey);
        }
        
        [HttpGet("surveyForUpdate/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSurveyForupdate(Guid id)
        {
            var survey = await _surveyService.GetSurveyForUpdateByIdAsync(id);

            if(survey is  null) { 
                return NotFound();
            }
            return Ok(survey);
        }

        [HttpGet("GetCreatedSurveys")]        
        public async Task<IActionResult> GetCreatedSurveys()
        {
            var survey = await _surveyService.GetSurveysByUserIdAsync(UserId);

            if(survey is  null) { 
                return NotFound();
            }
            return Ok(survey);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSurveyRequest request)
            {
            request.CreatedById = UserId;
            var id = await _surveyService.AddAsync(request);
            return Created($"/surveys/{id}",id);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateSurveyRequest request)
        {
            request.CreatedById = UserId;
            await _surveyService.UpdateAsync(request);
            return Ok(request);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid surveyId)
        {            
            await _surveyService.DeleteAsync(surveyId);
            return NoContent();
        }
    }
}
