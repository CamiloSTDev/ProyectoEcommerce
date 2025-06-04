using Application.Commands;
using FluentValidation;

namespace Application.Validators;

public class UpdateInventoryValidators : AbstractValidator<UpdateInventoryCommand>
{
    public UpdateInventoryValidators()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Por favor indique el inventario con el cual quiere interactuar");

        RuleFor(x => x.Stock)
            .NotEmpty().WithMessage("Indique la cantidad de stock nuevo")
            .GreaterThan(0).WithMessage("El stock no puede ser negativo o igual a 0");
    }
}