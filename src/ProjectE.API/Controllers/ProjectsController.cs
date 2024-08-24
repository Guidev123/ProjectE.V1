using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectE.API.DTOs.Projects;

namespace ProjectE.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post(CreateProjectDTO createProjectDTO)
        {
            return Ok();
        }
    }
}
