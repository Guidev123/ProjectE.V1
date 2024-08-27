﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectE.Application.Commands.Projects.CompleteProject;
using ProjectE.Application.Commands.Projects.CreateComment;
using ProjectE.Application.Commands.Projects.CreateProject;
using ProjectE.Application.Commands.Projects.DeleteProject;
using ProjectE.Application.Commands.Projects.StartProject;
using ProjectE.Application.Commands.Projects.UpdateProject;
using ProjectE.Application.Queries.Projects.GetAllProjects;
using ProjectE.Application.Queries.Projects.GetProjectById;

namespace ProjectE.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllProjectsQuery());

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetProjectByIdQuery(id));

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> CreateProjectAsync(CreateProjectCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProjectAsync(UpdateProjectCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _mediator.Send(new DeleteProjectCommand(id));

            if (!result.IsSuccess) return BadRequest(result.Message);

            return NoContent();
        }

        [HttpPut("complete/{id:guid}")]
        public async Task<ActionResult> CompleteProjectAsync(Guid id)
        {
            var result = await _mediator.Send(new CompleteProjectCommand(id));

            if (!result.IsSuccess) return BadRequest(result.Message);

            return NoContent();
        }

        [HttpPut("start/{id:guid}")]
        public async Task<ActionResult> StartProjectAsync(Guid id)
        {
            var result = await _mediator.Send(new StartProjectCommand(id));

            if (!result.IsSuccess) return BadRequest(result.Message);

            return NoContent();
        }

        [HttpPost("comments")]
        public async Task<ActionResult> CreateProjectCommentAsync(CreateCommentCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return NoContent();
        }
    }
}
