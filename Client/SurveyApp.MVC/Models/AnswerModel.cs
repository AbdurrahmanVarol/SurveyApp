﻿namespace SurveyApp.MVC.Models
{
    public class AnswerModel
    {
        public List<OptionalAnswerModel> OptionalAnswers { get; set; } = new List<OptionalAnswerModel>();
        public List<TextAnswerModel> TextAnswers { get; set; } = new List<TextAnswerModel>();
    }
}
