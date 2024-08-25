using Microsoft.AspNetCore.Mvc;
using ProjectE.Application.DTOs.Projects;
using ProjectE.Application.Services.Interfaces;

namespace ProjectE.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await _projectService.GetAllProjectsAsync();

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            var result = await _projectService.GetProjectByIdAsync(id);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> CreateProjectAsync(CreateProjectDTO createProject)
        {
            var result = await _projectService.CreateProjectAsync(createProject);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProjectAsync(UpdateProjectDTO updateProject)
        {
            var result = await _projectService.UpdateProjectAsync(updateProject);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _projectService.DeleteProjectAsync(id);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return NoContent();
        }

        [HttpPut("complete/{id:guid}")]
        public async Task<ActionResult> CompleteProjectAsync(Guid id)
        {
            var result = await _projectService.CompleteProjectAsync(id);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return NoContent();
        }

        [HttpPut("start/{id:guid}")]
        public async Task<ActionResult> StartProjectAsync(Guid id)
        {
            var result = await _projectService.StartProjectAsync(id);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return NoContent();
        }

        [HttpPost("comments/{id:guid}")]
        public async Task<ActionResult> CreateProjectCommentAsync(Guid id, CreateProjectCommentDTO createProjectComment)
        {
            var result = await _projectService.CreateProjectCommentAsync(id, createProjectComment);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return NoContent();
        }
    }
}
