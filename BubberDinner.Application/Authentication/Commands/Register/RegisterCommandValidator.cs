using FluentValidation;

namespace BubberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandValidtor : AbstractValidator<RegisterCommand>
{
    
    public RegisterCommandValidtor()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();

    }
}


