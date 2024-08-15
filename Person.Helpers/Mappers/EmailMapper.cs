using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person.Core.Dto.Registration.Request;
using Person.Core.Domain;

namespace Person.Helpers.Mappers
{
    public static class EmailMapper
    {
        public static EmailAddress toDomain(this EmailAddressDTO emailAddressDTO)
        {
            return new EmailAddress()
            {
                Email = emailAddressDTO.Email,
                EmailAddressPromotion = emailAddressDTO.EmailPromotion,
                CreatedAt=DateTime.Now,
                UpdatedAt=DateTime.Now,
            };
        }
    }
}
