using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Application.Interfaces.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTypesController : ControllerBase
    {
        private readonly IQuestionTypeService _questionTypeService;

        public QuestionTypesController(IQuestionTypeService questionTypeService)
        {
            _questionTypeService = questionTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var types = await _questionTypeService.GetAll();
            return Ok(types);
        }
    }
}
