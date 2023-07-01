﻿using Microsoft.AspNetCore.Http;
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
        private readonly ITextAnswerService _textAnswerService;

        private Guid UserId => Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

        public AnswersController(IAnswerService answerService, ITextAnswerService textAnswerService)
        {
            _answerService = answerService;
            _textAnswerService = textAnswerService;
        }

        [HttpGet("questionResult/{questionId}")]
        public async Task<IActionResult> GetQuestionResult(int questionId)
        {
            var result = await _answerService.GetAnswerResultByQuestionIdAsync(questionId);
            return Ok(result);
        }
        [HttpGet("surveyResult/{surveyId}")]
        public async Task<IActionResult> GetSurveyResult(Guid surveyId)
        {
            var result = await _answerService.GetAnswerResultsBySurveyIdAsync(surveyId);
            return Ok(result);
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
