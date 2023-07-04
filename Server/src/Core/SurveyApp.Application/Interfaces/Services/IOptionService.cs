using SurveyApp.Application.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Interfaces.Services
{
    public interface IOptionService
    {
        Task<int> AddAsync(CreateOptionRequest request);
        Task AddRangeAsync(IEnumerable<string> request,int questionId);
        Task DeleteAsync(int optionId);
        Task DeleteRangeAsync(IEnumerable<int> removedOptions);
    }
}
