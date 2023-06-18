using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Extensions.ValidationExtensions
{
    public static class FluentValidationExtensions
    {
        public static void ValidateAndThrowArgumentException<T>(this IValidator<T> validator, T instance)
        {
            var res = validator.Validate(instance);

            if (!res.IsValid)
            {
                var ex = new ValidationException(res.Errors);
                throw new ArgumentException(ex.Message, ex);
            }
        }
    }
}
