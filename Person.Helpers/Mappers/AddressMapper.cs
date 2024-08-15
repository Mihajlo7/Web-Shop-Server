using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person.Core.Dto.Registration.Request;
using Person.Core.Domain;

namespace Person.Helpers.Mappers
{
    public static class AddressMapper
    {
        public static Address toDomain (this AddressDTO addressDTO,Country country)
        {
            return new Address
            {
                AddressLine1 = addressDTO.AddressLine1,
                AddressLine2 = addressDTO.AddressLine2,
                City = addressDTO.City,
                PostalCode = addressDTO.PostalCode,
                Country=country,
                CreatedAt=DateTime.Now,
                UpdatedAt=DateTime.Now,

            };
        }
    }
}
