using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using BubberDinner.Domain.Common.Errors;
using BubberDinner.Domain.Entities;
using BubberDinner.Application.Authentication.Common;

namespace BubberDinner.Application.Authentication.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken)
    {

            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var user = new User()
            {
                FirstName= command.FirstName,
                LastName= command.LastName,
                Email= command.Email,
                Password= command.Password
            };

            _userRepository.Add(user);


            var token = _jwtTokenGenerator.GenerateToken(user);

            await Task.CompletedTask;


            return new AuthenticationResult(user, token);
    }
}

