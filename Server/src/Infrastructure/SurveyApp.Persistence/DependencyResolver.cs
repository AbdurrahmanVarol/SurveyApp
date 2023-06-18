using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveyApp.Application.Interfaces.Repositories;
using SurveyApp.Application.Interfaces.Services;
using SurveyApp.Persistence.EntityFramework.Contexts;
using SurveyApp.Persistence.EntityFramework.Repositories;
using SurveyApp.Persistence.Services;

namespace SurveyApp.Persistence
{
    public static class DependencyResolver
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServerConnectionString");

            services.AddDbContext<SurveyAppContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<DbContext, SurveyAppContext>();

            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<ISurveyRepository, EfSurveyRepository>();
            services.AddScoped<IQuestionRepository, EfQuestionRepository>();
            services.AddScoped<IOptionRepository, EfOptionRepository>();
            services.AddScoped<IAnswerRepository, EfAnswerRepository>();

            services.AddScoped<IUserService,UserService>();
            services.AddScoped<ISurveyService,SurveyService>();
        }
    }
}
