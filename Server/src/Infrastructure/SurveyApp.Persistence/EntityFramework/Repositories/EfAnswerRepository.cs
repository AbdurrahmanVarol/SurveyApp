using Microsoft.EntityFrameworkCore;
using SurveyApp.Application.Interfaces.Repositories;
using SurveyApp.Domain.ComplexTypes;
using SurveyApp.Domain.Entities;
using SurveyApp.Persistence.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        public async Task<IEnumerable<AnswerResult>> GetAnswerResultByQuestionIdAsync(int questionId)
        {
            var result = await (
                    from answer in _surveyAppContext.Answers
                    join option in _surveyAppContext.Options on answer.OptionId equals option.Id
                    where option.QuestionId == questionId
                    group new { answer, option } by new { option.Id, option.QuestionId } into g
                    select new AnswerResult
                    {
                        AnswerCount = g.Count(),
                        Option = _surveyAppContext.Options.FirstOrDefault(p => p.Id == g.Select(o => o.option.Id).First()),
                    }
                ).ToListAsync();
            return result;
        }

        public async Task<SurveyResult?> GetAnswerResultsBySurveyIdAsync(Guid surveyId)
        {
            var result = await (
                  from survey in _surveyAppContext.Surveys
                  where survey.Id == surveyId
                  select new SurveyResult
                  {
                      Survey = new Survey
                      {
                          CreatedAt = survey.CreatedAt,
                          CreatedById = survey.CreatedById,
                          CreatedBy = survey.CreatedBy,
                          Title = survey.Title,
                          Questions = new List<Question>(),
                          Id = survey.Id
                      },
                      //TODO:Enum
                      Questions = _surveyAppContext.Questions.Where(p => p.SurveyId == surveyId && (p.QuestionTypeId == 1 || p.QuestionTypeId == 2 || p.QuestionTypeId == 3)).Select(p => new QuestionResult
                      {
                          Question = new Question
                          {
                              QuestionTypeId = p.QuestionTypeId,
                              SurveyId = p.SurveyId,
                              Text = p.Text,
                              QuestionType = null,
                              Id = p.Id,
                              Options = null,
                              Survey = null,
                              TextAnswers = null,

                          },
                          Answers = (
                                     from answer in _surveyAppContext.Answers
                                     join option in _surveyAppContext.Options on answer.OptionId equals option.Id
                                     where option.QuestionId == p.Id
                                     group new { answer, option } by new { option.Id, option.QuestionId } into g
                                     select new AnswerResult
                                     {
                                         AnswerCount = g.Count(),
                                         Option = _surveyAppContext.Options.Select(p => new Option
                                         {
                                             Text = p.Text,
                                             QuestionId = p.QuestionId,
                                             Id = p.Id,
                                         }).First(p => p.Id == g.Select(o => o.option.Id).First())
                                     }
                                   ).ToList()
                      }).ToList()
                  }).FirstOrDefaultAsync();
            return result;
        }
    }
}
