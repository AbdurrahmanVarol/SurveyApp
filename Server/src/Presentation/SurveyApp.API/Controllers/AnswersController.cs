using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Application.Dtos.Requests;
using SurveyApp.Application.Interfaces.Services;
using SurveyApp.Domain.Entities;
using System.Security.Claims;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        private readonly IAnswerService2 _answerService2;
        private readonly ITextAnswerService _textAnswerService;

        private Guid UserId => Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

        public AnswersController(IAnswerService answerService, ITextAnswerService textAnswerService, IAnswerService2 answerService2)
        {
            _answerService = answerService;
            _textAnswerService = textAnswerService;
            _answerService2 = answerService2;
        }

        [HttpGet("questionResult/{questionId}")]
        public async Task<IActionResult> GetQuestionResult(int questionId)
        {
            var result = await _answerService.GetAnswerResultByQuestionIdAsync(questionId);
            return Ok(result);
        }
        //TODO:FİLTER
        [HttpGet("surveyResult/{surveyId}")]
        public async Task<IActionResult> GetSurveyResult(Guid surveyId)
        {
            var result = await _answerService.GetAnswerResultsBySurveyIdAsync(surveyId,UserId);
            return Ok(result);
        }

        [HttpPost("CreateSurveyAnswers")]
        public async Task<IActionResult> CreateSurveyAnswers(CreateSurveyAnswerRequest surveyAnswers)
        {
            await _answerService2.CreateSurveyAnswersAsync(surveyAnswers);
            return Ok(true);
        }

        [HttpPost("CreateOptionalAnswers")]
        public async Task<IActionResult> CreateOptionalAnswers(IEnumerable<CreateAnswerRequest> optionalAnswers)
        {
            await _answerService.AddRangeAsync(optionalAnswers);
            return Ok(true);
        }

        [HttpPost("CreateTextAnswers")]
        public async Task<IActionResult> CreateTextAnswers(IEnumerable<CreateTextAnswerRequest> textAnswers)
        {
            await _textAnswerService.AddRangeAsync(textAnswers);
            return Ok(true);
        }
    }
}
