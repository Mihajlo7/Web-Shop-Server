using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Mediator;
using Person.Core.Dto.Registration.Request;
using Person.Core.Dto.Registration.Response;

namespace Person.Mediator.Registration
{
    public sealed record RegistrationCommand(RegisterPersonDTO RegisterPerson ) : ICommand<RegisterResponseDTO>;
    
}
