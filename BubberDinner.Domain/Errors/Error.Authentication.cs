using ErrorOr;

namespace BubberDinner.Domain.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(code: "Auth.InvalidCredit",
                                                             description: "invalid credential");
                                                              
    }
}

