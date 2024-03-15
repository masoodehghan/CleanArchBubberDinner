using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;
using BubberDinner.Domain.Common.Errors;
using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        LoginQuery command,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserByEmail(command.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (user.Password != command.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }


            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
    }
}

