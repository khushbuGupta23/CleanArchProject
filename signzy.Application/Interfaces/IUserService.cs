using signzy.Domain.Entities;
using signzy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signzy.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<List<User>> GetAllUser();
     
    }
}
