using Application.Commands;
using FluentValidation;

namespace Application.Validators;

public class LoginCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email es requerido")
                .EmailAddress().WithMessage("Email debe tener un formato válido");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Contraseña es requerida");
        }
    }