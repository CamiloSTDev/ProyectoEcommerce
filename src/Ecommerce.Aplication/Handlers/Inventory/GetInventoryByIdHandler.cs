using MediatR;
using FluentValidation;
using Application.DTOs;
using Application.Commands;
using Application.Interfaces;

namespace Application.Handlers;

public class GetInventoryByIdHandler : IRequestHandler<GetByIdInventoryCommand, InventoryDto>
{
    private readonly IInventoryRepository _repository;
    private readonly IValidator<GetByIdInventoryCommand> _validator;

    public GetInventoryByIdHandler(IInventoryRepository repository, IValidator<GetByIdInventoryCommand> validator)
    {
        _repository = repository;
        _validator = validator;
    }
    public async Task<InventoryDto> Handle(GetByIdInventoryCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            var errors = string.Join(",", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException($"Errores de validacion {errors}");
        }

        return await _repository.GetInventoryByIdAsync(request.Id);
    }
}