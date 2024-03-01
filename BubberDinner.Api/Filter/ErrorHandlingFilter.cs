using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BubberDinner.Api.Filter;

public class ErrorHandlingFilterAttr : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var problemDetails = new ProblemDetails() 
        {
            Title = "an error occured",
            Status = (int)HttpStatusCode.InternalServerError,

        };
        var exception = context.Exception;
        context.Result   = new ObjectResult(problemDetails)
        {
            StatusCode = 500
        };
        context.ExceptionHandled = true;

    }
} 
