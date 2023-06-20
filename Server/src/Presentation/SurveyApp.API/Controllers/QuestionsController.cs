using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Application.Dtos.Requests;
using SurveyApp.Application.Dtos.Responses;
using SurveyApp.Application.Interfaces.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            return Ok(question);
        }

        [HttpGet("{surveyId}")]
        public async Task<IActionResult> GetBySurveyId(int surveyId)
        {
            var questions = await _questionService.GetQuestionsBySurveyIdAsync(surveyId);
            return Ok(questions);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateQuestionRequest questionRequest)
        {
            var id = await _questionService.AddAsync(questionRequest);
            return Created($"/question/{id}", id);
        }
    }
}
