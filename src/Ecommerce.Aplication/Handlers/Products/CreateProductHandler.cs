using Application.Commands;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _repository;
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IValidator<CreateProductCommand> _validator;

    public CreateProductHandler(IProductRepository repository,IInventoryRepository inventoryRepository, IValidator<CreateProductCommand> validator)
    {
        _repository = repository;
        _inventoryRepository = inventoryRepository;
        _validator = validator;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException($"Errores de validación: {errors}");
        }
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Desc = request.Description,
            Price = request.Price,
        };

        var inventory = new Inventory
        {
            Name = request.CategoryName,
            Stock = request.Stock,
            UpdatedAt = DateTime.UtcNow,
            ProductId = product.Id,
        };

        await _repository.CreateAsync(product);
        await _inventoryRepository.CreateInventoryAsync(inventory);

        var dto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Desc = product.Desc,
            Price = product.Price,
            Stock = inventory.Stock,
            CategoryName = inventory.Name,
        };
        return dto ;
    }

}