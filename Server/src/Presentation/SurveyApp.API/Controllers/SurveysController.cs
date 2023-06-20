using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Application.Dtos.Requests;
using SurveyApp.Application.Interfaces.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveysController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var survey = await _surveyService.GetSurveyByIdAsync(id);

            if(survey is  null) { 
                return NotFound();
            }
            return Ok(survey);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSurveyRequest request)
        {
            int id = await _surveyService.AddAsync(request);
            return Created($"/surveys/{id}",id);
        }
    }
}
