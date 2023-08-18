using signzy.Infrastucture.Interfaces;
using Microsoft.Extensions.Configuration;

namespace signzy.Infrastucture.Repositories
{
    public class ConnectionRepository : DapperRepository, IConnectionRepository
    {
        public ConnectionRepository(IConfiguration configuration)
        {
            Connectionstring = configuration.GetConnectionString("DefaultConnection");
        }
    }
}
