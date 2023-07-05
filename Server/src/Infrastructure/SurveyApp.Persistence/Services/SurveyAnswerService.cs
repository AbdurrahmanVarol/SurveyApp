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
    public class SurveyAnswerService : ISurveyAnswerService
    {
        private readonly IAnswerService _answerService;
        private readonly ITextAnswerService _textAnswerService;
        private readonly IDatabaseTransaction _databaseTransaction;

        public SurveyAnswerService(IAnswerService answerService, ITextAnswerService textAnswerService, IDatabaseTransaction databaseTransaction)
        {
            _answerService = answerService;
            _textAnswerService = textAnswerService;
            _databaseTransaction = databaseTransaction;
        }

        public async Task CreateSurveyAnswersAsync(CreateSurveyAnswerRequest request)
        {
            using var transaction = await _databaseTransaction.BeginTransactionAsync();
            try
            {
                await _answerService.AddRangeAsync(request.OptionalAnswers);
                await _textAnswerService.AddRangeAsync(request.TextAnswers);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
