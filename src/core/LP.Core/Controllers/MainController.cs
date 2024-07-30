using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP.Core.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ICollection<string> Errors = [];
        protected ActionResult CustomResponse(object? result = null)
        {
            if (ValidOperation()) return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Messages", Errors.ToArray() }
            }));
        }
        protected ActionResult CustomResponse(ModelStateDictionary modelState) // Valid Models errors
        {
            var errors = modelState.Values.SelectMany(x => x.Errors);
            foreach (var error in errors) AddError(error.ErrorMessage);
            return CustomResponse();
        }
        protected bool ValidOperation() => !Errors.Any();

        protected void AddError(string error) => Errors.Add(error);

        protected void ClearProcessErrors() => Errors.Clear();

    }
}
