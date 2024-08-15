using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Mediator;
using Microsoft.EntityFrameworkCore;
using Person.Core.Dto.Registration.Request;
using Person.Core.Dto.Registration.Response;
using Person.Helpers.Mappers;
using Person.Repository;

namespace Person.Mediator.Registration
{

    public class RegistrationHandler : ICommandHandler<RegistrationCommand, RegisterResponseDTO>
    {
        private readonly IPersonRepository _personRepository;

        public RegistrationHandler(IPersonRepository personRepository)
        {
            _personRepository=personRepository;
        }
        public async Task<RegisterResponseDTO> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var countryCode = request.RegisterPerson.Address.CountryCode;
            var foundedCountry = await _personRepository.GetCountryByCode(countryCode);
            if(foundedCountry == null) 
            {
                throw new Exception($"Country code {countryCode} does not exist!");
            }
            var newPerson = request.RegisterPerson.CreatePerson(foundedCountry);
            try
            {
                var registratedPerson = await _personRepository.RegisterPerson(newPerson);
                if(registratedPerson == null)
                {
                    return new RegisterResponseDTO
                    {
                        Id = Guid.Empty,
                        Message = "Registration has been currapted!"
                    };
                }
                else
                {
                    return new RegisterResponseDTO
                    {
                        Id = registratedPerson.Id,
                        Message = "Registration has been succefull!"
                    };
                }
            } catch(DbUpdateException ex)
            {
                throw new Exception($"Saving new Person is unsuccefull!");
            }
            
        }
    }
}
