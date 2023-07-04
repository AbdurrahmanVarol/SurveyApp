using Refit;
using SurveyApp.MVC.Refit;
using System.Net.Http.Headers;

namespace SurveyApp.MVC.Extensions
{
    public static class RefitClientExtension
    {
        public static IServiceCollection AddRefitClients(this IServiceCollection services, IConfiguration configuration)
        {
            var baseAdress = configuration.GetSection("Refit:BaseAdress").Value;

            services.AddRefitClient(typeof(IAuthApi)).ConfigureHttpClient(option =>
            {
                option.BaseAddress = new Uri(baseAdress);
                option.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddRefitClient(typeof(ISurveyApi)).ConfigureHttpClient(option =>
            {
                option.BaseAddress = new Uri(baseAdress);
                option.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            services.AddRefitClient(typeof(IAnswerApi)).ConfigureHttpClient(option =>
            {
                option.BaseAddress = new Uri(baseAdress);
                option.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            services.AddRefitClient(typeof(IQuestionTypeApi)).ConfigureHttpClient(option =>
            {
                option.BaseAddress = new Uri(baseAdress);
                option.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            return services;
        }
    }
}
