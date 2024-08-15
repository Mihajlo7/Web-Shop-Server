using MediatR;
using Microsoft.AspNetCore.Mvc;
using Person.Core.Dto.Registration.Request;
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
    }
}
