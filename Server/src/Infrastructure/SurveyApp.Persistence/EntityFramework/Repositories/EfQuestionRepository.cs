using SurveyApp.Application.Interfaces.Repositories;
using SurveyApp.Domain.Entities;
using SurveyApp.Persistence.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Persistence.EntityFramework.Repositories
{
    public class EfQuestionRepository : EfEntityRepositoryBase<Question, SurveyAppContext>, IQuestionRepository
    {
        public EfQuestionRepository(SurveyAppContext context) : base(context)
        {
        }
    }
}
