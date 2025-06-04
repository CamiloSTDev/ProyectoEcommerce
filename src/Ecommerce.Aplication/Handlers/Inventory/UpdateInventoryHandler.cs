using Application.Commands;
using Application.DTOs;
using Application.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.Handlers;

public class UpdateInventoryHandler : IRequestHandler<UpdateInventoryCommand, InventoryDto>
{
    private readonly IInventoryRepository _repository;
    private readonly IValidator<UpdateInventoryCommand> _validator;
    public UpdateInventoryHandler(IInventoryRepository repository, IValidator<UpdateInventoryCommand> validator)
    {
        _repository = repository;
        _validator = validator;
    }
    public async Task<InventoryDto> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException($"Errores de validación: {errors}");
        }

        return await _repository.UpdateInventoryAsync(request.Id, request.Stock);


    }
}