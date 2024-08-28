using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectE.Application.Commands.Skills.CreateSkill;
using ProjectE.Application.Queries.Customers.GetCustomerById;
using ProjectE.Application.Queries.Skills.GetSkillsByCustomerId;

namespace ProjectE.API.Controllers
{
    [ApiController]
    [Route("api/skills")]
    [Authorize]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("customer-skills/{id:guid}")]
        public async Task<ActionResult> GetCustomerSkillsById(Guid id)
        {
            var result = await _mediator.Send(new GetSkillsByCustomerIdCommand(id));

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSkillAsync(CreateSkillCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

    }
}
