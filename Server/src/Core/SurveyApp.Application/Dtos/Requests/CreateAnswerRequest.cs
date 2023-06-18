using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Requests
{
    public class CreateAnswerRequest
    {
        public int OptionId { get; set; }
        public int? UserId { get; set; }
    }
}
