using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectE.API.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            return Ok();
        }
    }
}
