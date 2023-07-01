﻿using SurveyApp.Domain.ComplexTypes;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Responses
{
    public class QuestionResultResponse
    {
        public QuestionDisplayResponse Question { get; set; }

        public IEnumerable<AnswerResultResponse> Answers { get; set; }
    }
}
