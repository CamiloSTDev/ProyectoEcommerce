using FluentValidation;
using Application.Commands;

namespace Application.Validators;

public class RegisterCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email es requerido")
            .EmailAddress().WithMessage("Email debe tener un formato válido");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Contraseña es requerida")
            .MinimumLength(8).WithMessage("Contraseña debe tener al menos 8 caracteres")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]")
            .WithMessage("Contraseña debe contener al menos: 1 minúscula, 1 mayúscula, 1 número y 1 carácter especial");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Confirmación de contraseña es requerida")
            .Equal(x => x.Password).WithMessage("Las contraseñas no coinciden");

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Nombre de usuario es requerido")
            .MinimumLength(2).WithMessage("Nombre de usuario debe tener al menos 2 caracteres")
            .MaximumLength(50).WithMessage("Nombre de usuario no puede exceder 50 caracteres");


    }
}