using Microsoft.EntityFrameworkCore;
using SurveyApp.Application.Interfaces.Repositories;
using SurveyApp.Domain.ComplexTypes;
using SurveyApp.Domain.Entities;
using SurveyApp.Persistence.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Persistence.EntityFramework.Repositories
{
    public class EfAnswerRepository : EfEntityRepositoryBase<Answer, SurveyAppContext>, IAnswerRepository
    {
        private readonly SurveyAppContext _surveyAppContext;
        public EfAnswerRepository(SurveyAppContext context) : base(context)
        {
            _surveyAppContext = context;
        }

        public async Task<AnswerResult> GetAnswerResultByQuestionIdAsync(int questionId)
        {
            var result = await (
                    from answer in _surveyAppContext.Answers
                    join option in _surveyAppContext.Options on answer.OptionId equals option.Id
                    where option.QuestionId == questionId
                    group new {answer,option} by new {option.Id,option.QuestionId} into g
                    select new AnswerResult
                    {
                        AnswerCount = g.Count(),
                        Option = _surveyAppContext.Options.FirstOrDefault(p=>p.Id == g.Select(o=>o.option).FirstOrDefault().Id),
                        Question = _surveyAppContext.Questions.FirstOrDefault(p=>p.Id == g.Select(o=>o.option).FirstOrDefault().QuestionId)
                    }
                ).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<AnswerResult>> GetAnswerResultsBySurveyIdAsync(int surveyId)
        {
            var result = await (
                  from answer in _surveyAppContext.Answers
                  join option in _surveyAppContext.Options on answer.OptionId equals option.Id
                  join question in _surveyAppContext.Questions on option.QuestionId equals question.Id
                  where question.SurveyId == surveyId
                  group new { answer, option } by new { option.Id, option.QuestionId } into g
                  select new AnswerResult
                  {
                      AnswerCount = g.Count(),
                      Option = _surveyAppContext.Options.FirstOrDefault(p => p.Id == g.Select(o => o.option).FirstOrDefault().Id),
                      Question = _surveyAppContext.Questions.FirstOrDefault(p => p.Id == g.Select(o => o.option).FirstOrDefault().QuestionId)
                  }
              ).ToListAsync();
            return result;
        }
    }
}
