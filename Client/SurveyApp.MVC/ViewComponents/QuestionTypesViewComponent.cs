using Microsoft.AspNetCore.Mvc;
using SurveyApp.MVC.Caching;
using SurveyApp.MVC.Models;
using SurveyApp.MVC.Refit;

namespace SurveyApp.MVC.ViewComponents
{
    public class QuestionTypesViewComponent : ViewComponent
    {
        private readonly IQuestionTypeApi _questionTypeApi;
        private readonly ICache _cache;

        public QuestionTypesViewComponent(IQuestionTypeApi questionTypeApi, ICache cache)
        {
            _questionTypeApi = questionTypeApi;
            _cache = cache;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? selectedType)
        {
            var cachedQuestionTypes = _cache.Get<IEnumerable<QuestionTypeModel>>("questionTypes");
            if (cachedQuestionTypes == null)
            {
                var questionTypes = await _questionTypeApi.GetQuestionTypes();
                _cache.Set("questionTypes", questionTypes, TimeSpan.FromMinutes(20));
                cachedQuestionTypes = questionTypes;
            }

            var model = new QuestionTypeViewModel
            {
                QuestionTypes = cachedQuestionTypes,
                SelectedType = selectedType
            };
            return View(model);
        }
    }
}
