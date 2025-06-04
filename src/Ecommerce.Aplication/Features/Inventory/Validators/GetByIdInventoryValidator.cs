using MediatR;
using FluentValidation;
using Application.Commands;

namespace Application.Validators;

public class GetByIdInventoryValidator : AbstractValidator<GetByIdInventoryCommand>
{
    public GetByIdInventoryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Indique el Inventario a seleccionar");
    }
}