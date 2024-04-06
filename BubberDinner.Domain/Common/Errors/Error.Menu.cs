using System.Net;
using ErrorOr;
using Microsoft.AspNetCore.Http;

namespace BubberDinner.Domain.Common.Errors;

public partial class Errors
{
    public static class Menu
    {
        public static Error NotFound => Error.NotFound();
    }
}
