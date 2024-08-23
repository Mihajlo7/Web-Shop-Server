using Person.Core.Domain;

namespace Person.Repository
{
    public interface IPersonRepository
    {
        public Task<Country> GetCountryByCode(string code);
        public Task<Person.Core.Domain.Person> RegisterPerson(Person.Core.Domain.Person person);
        public Task<Person.Core.Domain.Person> CheckPersonEmail(string email);
        public Task<Person.Core.Domain.Person> UpdatePerson(Person.Core.Domain.Person person);
        public Task<Password> ChangePassword(Guid personId,Password password);
        public Task<Password> CheckPersonPassword(Guid id);
    }
}
