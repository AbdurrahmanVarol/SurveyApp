﻿using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Responses
{
    public class OptionResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }

    }
}
