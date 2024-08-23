using MediatR;
using Microsoft.AspNetCore.Mvc;
using Person.Core.Dto.ChangePassword;
using Person.Core.Dto.Login;
using Person.Core.Dto.Registration.Request;
using Person.Mediator.ChangePassword;
using Person.Mediator.Login;
using Person.Mediator.Registration;

namespace WebShopApi.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("add")]
        public async Task<IActionResult> RegisterPerson([FromBody] RegisterPersonDTO request)
        {
            return Ok(await _mediator.Send(new RegistrationCommand(request)));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginPerson([FromBody] LoginPersonDTO request)
        {
            return Ok(await _mediator.Send(new LoginQuery(request)));
        }
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO request)
        {
            return Ok(await _mediator.Send(new ChangePasswordCommand(request)));
        }
    }
}
