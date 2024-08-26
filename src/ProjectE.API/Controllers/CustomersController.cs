using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectE.Application.Commands.Customers.CreateCustomers;
using ProjectE.Application.Commands.Customers.DeleteCustomers;
using ProjectE.Application.Queries.Customers.GetCustomerById;
using ProjectE.Application.Queries.Customers.GetCustomerProjectsById;

namespace ProjectE.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomersController(IMediator mediator) => _mediator = mediator;


        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetCustomerByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetCustomerByIdQuery(id));

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpGet("get-projects/{id:guid}")]
        public async Task<ActionResult> GetCustomerProjectsByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetCustomerProjectsByIdQuery(id));

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> CreateCustomerAsync(CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);

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
