using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TruckManager.Api.Controllers
{
    public class ErrorController : ApiController
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            return Problem(title: exception?.Message);
        }
    }
}
