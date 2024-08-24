using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectE.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class CustomersController : ControllerBase
    {
        [HttpPost("")]
        public async Task<ActionResult> Post()
        {
            return Ok();
        }
    }
}
