using Microsoft.Extensions.Configuration;

namespace ConnectionService
{
    public class ConnectionServiceImp : IConnectionService
    {
        private readonly IConfiguration _configuration;
        private string relationDatabase;

        public ConnectionServiceImp(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetRelationString()
        {
           relationDatabase= _configuration["Relation:SqlServer"];
           return relationDatabase;
        }
    }
}
