using SurveyApp.Application.Dtos.Requests;
using SurveyApp.Application.Interfaces.Services;
using SurveyApp.Application.Interfaces.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Persistence.Services
{
    public class AnswerService2 : IAnswerService2
    {
        private readonly IAnswerService _answerService;
        private readonly ITextAnswerService _textAnswerService;
        private readonly IDatabaseTransaction _databaseTransaction;

        public AnswerService2(IAnswerService answerService, ITextAnswerService textAnswerService, IDatabaseTransaction databaseTransaction)
        {
            _answerService = answerService;
            _textAnswerService = textAnswerService;
            _databaseTransaction = databaseTransaction;
        }

        public async Task CreateSurveyAnswersAsync(CreateSurveyAnswerRequest request)
        {
            try
            {
                await _answerService.AddRangeAsync(request.OptionalAnswers);
                await _textAnswerService.AddRangeAsync(request.TextAnswers);
                await _databaseTransaction.Commit();
            }
            catch(Exception ex)
            {
                await _databaseTransaction.Rollback();
                throw ex;
            }
            finally 
            {
                await _databaseTransaction.DisposeAsync();
            }
        }
    }
}
