using SurveyApp.Application.Interfaces.Services;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Persistence.Services
{
    public class UserService : IUserService
    {
        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByRefreshTokenAndUserIdAsync(string refreshToken, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
