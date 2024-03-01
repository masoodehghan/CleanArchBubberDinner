using System.Net;
using FluentResults;

namespace BubberDinner.Application.Common.Errors;





public  class DuplicateEmailError : IError
{
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => throw new Exception();

    public Dictionary<string, object> Metadata => new();
}

