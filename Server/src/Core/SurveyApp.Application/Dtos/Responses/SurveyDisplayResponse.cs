﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Responses
{
    public class SurveyDisplayResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
