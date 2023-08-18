
using Microsoft.Extensions.Configuration;
using signzy.Infrastucture.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signzy.Application.Services
{
    public class BaseService : ApiServiceBase
    {
        public BaseService(IConfiguration configuration, IConnectionRepository connectionrepo) : base(connectionrepo)
        {

        }


    }
}
