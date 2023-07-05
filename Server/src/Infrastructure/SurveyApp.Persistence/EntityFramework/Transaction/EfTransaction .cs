using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyApp.Application.Interfaces.Transaction;
using SurveyApp.Persistence.EntityFramework.Contexts;

namespace SurveyApp.Persistence.EntityFramework.Transaction
{
    public class EfTransaction : IDatabaseTransaction
    {
        private readonly SurveyAppContext _appContext;


        public EfTransaction(SurveyAppContext context)
        {
            _appContext = context;
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _appContext.Database.BeginTransactionAsync();
        }
       

       
    }
}
