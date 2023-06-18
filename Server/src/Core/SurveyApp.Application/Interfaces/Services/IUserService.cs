using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUserByUserNameAsync(string userName);
        Task AddAsync(User user);
        Task<User> GetUserByRefreshTokenAndUserIdAsync(string refreshToken);
    }
}
