using Person.Core.Domain;

namespace Person.Repository
{
    public interface IPersonRepository
    {
        public Task<Country> GetCountryByCode(string code);
        public Task<Person.Core.Domain.Person> RegisterPerson(Person.Core.Domain.Person person);
        public Task<Person.Core.Domain.Person> CheckPersonEmail(string email);
        public Task<Password> CheckPersonPassword(Guid id);
    }
}
