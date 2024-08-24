using Microsoft.AspNetCore.Mvc;

namespace ProjectE.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult> GetByIdAsync()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> PostAsync()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync()
        {
            return Ok();
        }
    }
}
