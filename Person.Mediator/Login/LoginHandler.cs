using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Mediator;
using Person.Core.Dto.Login;
using Person.Helpers.PasswordMaker;
using Person.Repository;

namespace Person.Mediator.Login
{
    public sealed class LoginHandler : IQueryHandler<LoginQuery, LoginResponseDTO>
    {
        private readonly IPersonRepository _personRepository;

        public LoginHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<LoginResponseDTO> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            bool found = true;
            var emailForSearch=request.LoginPersonDTO.Email;
            var foundedPerson = await  _personRepository.CheckPersonEmail(emailForSearch);
            if (foundedPerson == null)
            {
                found = false;
            }
            else
            {
                var activePassword=foundedPerson.Passwords.FirstOrDefault(password=>password.IsActive);
                if 
                    (activePassword == null || !PasswordMaker.VerifyPassword
                    (request.LoginPersonDTO.Password,activePassword.PasswordHash, Convert.FromBase64String(activePassword.PasswordSalt)))
                {
                    found = false;
                }
                
            }
            LoginResponseDTO response = new LoginResponseDTO();
            response.Success = found;
            if (response.Success)
            {
                response.Message = "Login has been succefull!";
            }
            else
            {
                response.Message = "Email or Password is not correct!";
            }

            return response;
        }
    }
}
