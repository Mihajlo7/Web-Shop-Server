using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Core.Dto.Registration.Request
{
    public class RegisterPersonDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Telephone { get; set; }
        public PasswordDTO Password { get; set; }
        public EmailAddressDTO EmailAddress { get; set; }
        public AddressDTO Address { get; set; }
        public CreditCardDTO CreditCard { get; set; }
    }
}
