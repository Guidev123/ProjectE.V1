using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectE.Application.Commands.Customers.CreateCustomer;
using ProjectE.Application.Commands.Customers.DeleteCustomer;
using ProjectE.Application.Commands.Customers.LoginCustomer;
using ProjectE.Application.Queries.Customers.GetCustomerById;
using ProjectE.Application.Queries.Customers.GetCustomerProjectsById;

namespace ProjectE.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomersController(IMediator mediator) => _mediator = mediator;


        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<ActionResult> CreateCustomerAsync(CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(command);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> LoginCustomerAsync(LoginCustomerCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetCustomerByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetCustomerByIdQuery(id));

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("projects/{id:guid}")]
        public async Task<ActionResult> GetCustomerProjectsByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetCustomerProjectsByIdQuery(id));

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteCustomerAsync(Guid id)
        {
            var result = await _mediator.Send(new DeleteCustomerCommand(id));

            if (!result.IsSuccess) return BadRequest(result.Message);

            return NoContent();
        }
    }
}
