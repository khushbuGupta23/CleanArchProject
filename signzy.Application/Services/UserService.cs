using Microsoft.Extensions.Configuration;
using signzy.Application.Interfaces;
using signzy.Domain.Entities;
using signzy.Infrastucture.Interfaces;

namespace signzy.Application.Services
{
    public class UserService : BaseService, IUserService
    {
        public IConfiguration _configuration;

        public UserService(IConfiguration configuration, IConnectionRepository connectionRepository) : base(configuration, connectionRepository)
        {
            _configuration = configuration;
        }

        public Task<User> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUser()
        {
            throw new NotImplementedException();
        }
    }
    }
