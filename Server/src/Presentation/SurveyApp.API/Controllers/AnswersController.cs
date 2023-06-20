using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Application.Dtos.Requests;
using SurveyApp.Application.Interfaces.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswersController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet("{questionId}")]
        public async Task<IActionResult> GetQuestionResult(int questionId)
        {
            var result = await _answerService.GetAnswerResultByQuestionIdAsync(questionId);
            return Ok(result);
        }
        [HttpGet("{surveyId}")]
        public async Task<IActionResult> GetSurveyResult(int surveyId)
        {
            var result = await _answerService.GetAnswerResultsBySurveyIdAsync(surveyId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAnswerRequest request)
        {
            var id = await _answerService.AddAsync(request);
            return Ok(id);
        }
    }
}
