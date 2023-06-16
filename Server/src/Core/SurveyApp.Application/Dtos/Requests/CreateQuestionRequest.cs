﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Requests
{
    public class CreateQuestionRequest
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
    }
}
