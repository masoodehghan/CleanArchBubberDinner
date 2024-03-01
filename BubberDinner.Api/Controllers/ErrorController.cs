using BubberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers;

public class ErrorController: ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            ISerciceException serciceException => 
                        ((int)serciceException.StatusCode, serciceException.ErrorMessage),
            
            _ => (StatusCodes.Status500InternalServerError, "")
        };

        return Problem(statusCode: statusCode, title: message);
    }
}

