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
        private IDbContextTransaction _transaction;

        public EfTransaction(SurveyAppContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }

        public async Task Commit() => await _transaction.CommitAsync();
        
        public async Task Rollback() => await _transaction.RollbackAsync();

        public async ValueTask DisposeAsync() => await _transaction.DisposeAsync();
       
    }
}
