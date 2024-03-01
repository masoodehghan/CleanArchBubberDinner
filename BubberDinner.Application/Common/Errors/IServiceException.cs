using System.Net;

namespace BubberDinner.Application.Common.Errors;

public interface ISerciceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "email already exist";
}
