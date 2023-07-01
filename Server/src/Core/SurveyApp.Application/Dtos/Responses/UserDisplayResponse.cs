using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Responses
{
    public class UserDisplayResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }
}
