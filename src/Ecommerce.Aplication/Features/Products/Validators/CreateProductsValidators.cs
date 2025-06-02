
using Application.Commands;
using FluentValidation;

namespace Application.Validators;

public class CreateProductsValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductsValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre del producto no puede estar vacio")
            .MinimumLength(5).WithMessage("Nombre del producto debe tener al menos 5 caracteres")
            .MaximumLength(80).WithMessage("Nombre del producto no puede exceder 80 caracteres");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Descripciòn no puede estar vacia, por favor describa sobre que trata el producto");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Por Favor indique el precio del producto")
            .GreaterThan(0).WithMessage("Ingrese un precio valido");
    }
}