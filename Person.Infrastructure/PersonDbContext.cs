using Generic.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Person.Infrastructure
{
    public class PersonDbContext : AppDbContext
    {
        
        public PersonDbContext(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
