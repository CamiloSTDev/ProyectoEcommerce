
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
            .NotEmpty().WithMessage("La descripción no puede estar vacía, por favor describa de qué trata el producto");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Por Favor indique el precio del producto")
            .GreaterThan(0).WithMessage("Ingrese un precio valido");

        RuleFor(x => x.Stock)
            .NotEmpty().WithMessage("El valor de unidades disponibles no debe de estar vacio")
            .GreaterThan(0).WithMessage("Las unidades deben ser mayor a 0");

        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("El nombre de la categoria del producto no puede estar vacio")
            .MinimumLength(5).WithMessage("Nombre de la categoria del producto debe tener al menos 5 caracteres")
            .MaximumLength(50).WithMessage("Nombre de la categoria del producto no puede exceder 50 caracteres");

    }
}