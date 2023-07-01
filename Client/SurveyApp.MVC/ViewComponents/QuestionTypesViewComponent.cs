using Microsoft.AspNetCore.Mvc;
using SurveyApp.MVC.Models;
using SurveyApp.MVC.Refit;

namespace SurveyApp.MVC.ViewComponents
{
    public class QuestionTypesViewComponent : ViewComponent
    {
        private readonly IQuestionTypeApi _questionTypeApi;

        public QuestionTypesViewComponent(IQuestionTypeApi questionTypeApi)
        {
            _questionTypeApi = questionTypeApi;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? selectedType)
        {
            var questionTypes = await _questionTypeApi.GetQuestionTypes();
            var model = new QuestionTypeViewModel
            {
                QuestionTypes = questionTypes,
                SelectedType = selectedType
            };
            return View(model);
        }
    }
}
