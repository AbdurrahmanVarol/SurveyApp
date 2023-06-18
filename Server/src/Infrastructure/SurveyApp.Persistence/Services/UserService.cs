using SurveyApp.Application.Interfaces.Repositories;
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
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddAsync(User user)
        {
            await _userRepository.AddAsync(user);           
        }

        public async Task<User> GetUserByRefreshTokenAndUserIdAsync(string refreshToken)
        {
            var user = await _userRepository.GetAsync(p => p.RefreshToken.Equals(refreshToken));
            return user;
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            var user = await _userRepository.GetAsync(p => p.UserName.Equals(userName));
            return user;
        }
    }
}
