﻿using SurveyApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public required int Id { get; set; }

        public required int OptionId { get; set; }
        public required Option Option { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
