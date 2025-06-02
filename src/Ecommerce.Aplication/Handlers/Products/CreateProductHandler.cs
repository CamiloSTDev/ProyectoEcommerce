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
    private readonly IValidator<CreateProductCommand> _validator;

    public CreateProductHandler(IProductRepository repository, IValidator<CreateProductCommand> validator)
    {
        _repository = repository;
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

        await _repository.CreateAsync(product);

        var dto = new ProductDto
        {   
            Id = product.Id,
            Name = product.Name,
            Desc = product.Desc,
            Price = product.Price
        };
        return dto ;
    }

}