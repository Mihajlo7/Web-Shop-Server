using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person.Core.Dto.Registration.Request;
using Person.Core.Domain;
using Person.Helpers.PasswordMaker;

namespace Person.Helpers.Mappers
{
    public static class CreatorPerson
    {
        public static Core.Domain.Person CreatePerson(this RegisterPersonDTO registerPersonDTO,Country country)
        {
            Core.Domain.Person person = new Core.Domain.Person();
            person.FirstName = registerPersonDTO.FirstName;
            person.LastName = registerPersonDTO.LastName;
            person.BirthDate = registerPersonDTO.BirthDay;
            person.Telephone = registerPersonDTO.Telephone;
            person.EmailAddress=registerPersonDTO.EmailAddress.toDomain();

            person.CreditCards = registerPersonDTO.CreditCard.CreateCreditCard();
            person.Adresses = registerPersonDTO.Address.CreateAddress(country);
            person.Passwords = registerPersonDTO.Password.GeneratePassword();

            person.CreatedAt= DateTime.Now;
            person.UpdatedAt= DateTime.Now;

            return person;
            
        }
        
        public static ICollection<BussinessEntitityCreditCard> CreateCreditCard(this CreditCardDTO creditCardDTO)
        {
            BussinessEntitityCreditCard creditCardBuss = new BussinessEntitityCreditCard()
            {
                CreditCard = creditCardDTO.toDomain(),
                CreatedAt=DateTime.Now,
                UpdatedAt=DateTime.Now,
            };
            
            return [creditCardBuss];
        }

        public static ICollection<BusinessEntityAdress> CreateAddress(this AddressDTO addressDTO,Country country)
        {
            BusinessEntityAdress businessEntityAdress = new BusinessEntityAdress
            {
                Address = addressDTO.toDomain(country),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            return [businessEntityAdress];
        }

        public static ICollection<Password> GeneratePassword(this PasswordDTO passwordDTO)
        {
            var hash = PasswordMaker.PasswordMaker.HashPassword(passwordDTO.NewPassword, out var salt);
            Password createdPassword =
                new Password
                {
                    PasswordHash = hash,
                    PasswordSalt = Convert.ToBase64String(salt),
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
            return [createdPassword];
        }
    }
}
