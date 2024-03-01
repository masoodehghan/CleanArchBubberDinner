using ErrorOr;

namespace BubberDinner.Domain.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail",
                                                             description: "email exist");
                                                              
    }
}

