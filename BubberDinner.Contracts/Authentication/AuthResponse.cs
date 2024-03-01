using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BubberDinner.Contracts.Authentication
{
    public record AuthResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token
        );
}
