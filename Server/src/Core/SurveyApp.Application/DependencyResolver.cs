using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SurveyApp.Application.Validators.FluentValidation;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application
{
    public static class DependencyResolver
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);

            services.AddValidatorsFromAssembly(assembly);
        }
    }
}
