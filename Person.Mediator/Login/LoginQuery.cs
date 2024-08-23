using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Mediator;
using Person.Core.Dto.Login;

namespace Person.Mediator.Login
{
    public sealed record LoginQuery(LoginPersonDTO LoginPersonDTO): IQuery<LoginResponseDTO>;
    
}
