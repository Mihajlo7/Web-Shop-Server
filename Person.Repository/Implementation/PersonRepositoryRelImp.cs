using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Person.Core.Domain;
using Person.Helpers.PasswordMaker;

namespace Person.Repository.Implementation
{
    public class PersonRepositoryRelImp(AppDbContext context) : IPersonRepository
    {
        private readonly AppDbContext _context=context;


        public async Task<Country> GetCountryByCode(string code)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Code == code);
        }

        public async Task<Core.Domain.Person> CheckPersonEmail(string email)
        {
            return await _context.Persons
                .FirstOrDefaultAsync(person => person.EmailAddress.Email == email);
        }

        

        public async Task<Core.Domain.Person> RegisterPerson(Core.Domain.Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<Password> CheckPersonPassword(Guid id)
        {
            return await _context.Passwords.FirstOrDefaultAsync(pass => pass.Id == id);
        }

        public async Task<Core.Domain.Person> UpdatePerson(Core.Domain.Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<Password> ChangePassword(Guid personId, Password password)
        {
            var activePassword=  await _context.Passwords.FirstOrDefaultAsync(password=> password.PersonId == personId && password.IsActive==true);

            activePassword.IsActive=false;
            activePassword.UpdatedAt= DateTime.Now;

            _context.Passwords.Add(password);
            await _context.SaveChangesAsync();
            return password;
        }
    }
}
