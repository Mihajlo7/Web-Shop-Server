using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person.Core.Dto.Registration.Request;
using Person.Core.Domain;

namespace Person.Helpers.Mappers
{
    public static class CreditCardMapper
    {
        public static CreditCard toDomain(this CreditCardDTO creditCardDTO)
        {
            return new CreditCard()
            {
                Number = creditCardDTO.Number,
                Type = creditCardDTO.Type,
                ExpMonth = creditCardDTO.ExpMonth,
                ExpYear = creditCardDTO.ExpYear,
                CreatedAt=DateTime.Now,
                UpdatedAt=DateTime.Now,
            };
        }
    }
}
