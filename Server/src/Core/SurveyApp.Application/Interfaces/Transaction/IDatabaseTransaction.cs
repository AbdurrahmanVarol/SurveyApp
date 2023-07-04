using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Interfaces.Transaction
{

    public interface IDatabaseTransaction : IAsyncDisposable
    {
        Task Commit();

        Task Rollback();
    }

}
