using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Mediator;
using Person.Core.Dto.ChangePassword;

namespace Person.Mediator.ChangePassword
{
    public sealed record ChangePasswordCommand(ChangePasswordDTO ChangePasswordDTO): ICommand<ChangePasswordResponse>;
    
}
