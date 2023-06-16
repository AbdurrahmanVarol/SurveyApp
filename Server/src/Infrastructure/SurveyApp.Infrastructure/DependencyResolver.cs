using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveyApp.Application.Interfaces.Repositories;
using SurveyApp.Application.Interfaces.Services;
using SurveyApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure
{
    public static class DependencyResolver
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
