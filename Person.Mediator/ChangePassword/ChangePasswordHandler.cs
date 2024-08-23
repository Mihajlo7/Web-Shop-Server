using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Mediator;
using Person.Core.Domain;
using Person.Core.Dto.ChangePassword;
using Person.Core.Dto.Registration.Request;
using Person.Helpers.Mappers;
using Person.Helpers.PasswordMaker;
using Person.Repository;

namespace Person.Mediator.ChangePassword
{
    public sealed class ChangePasswordHandler : ICommandHandler<ChangePasswordCommand, ChangePasswordResponse>
    {
        private readonly IPersonRepository _personRepository;

        public ChangePasswordHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var foundPerson= await _personRepository.CheckPersonEmail(request.ChangePasswordDTO.Email);
            if (foundPerson == null)
            {
                throw new Exception("Email does not exist!");
            }
            PasswordDTO passwordDTO = new PasswordDTO()
            {
                NewPassword = request.ChangePasswordDTO.NewPassword,
                ConfirmedPassword = request.ChangePasswordDTO.ConfirmedNewPassword
            };
            Password password = passwordDTO.GeneratePassword();
            password.Person = foundPerson;

            var newPassword = await _personRepository.ChangePassword(foundPerson.Id, password);
            return new ChangePasswordResponse 
            { Id = newPassword.Id, Message = "Message has been changed successfull!" };
        }
    }
}
