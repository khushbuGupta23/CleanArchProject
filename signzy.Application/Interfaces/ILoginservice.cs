using signzy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signzy.Application.Interfaces
{
    public interface ILoginservice
    {
        Task<LoginAuth> AuthenticateAsync(string UserName, string Password);
    }
}
