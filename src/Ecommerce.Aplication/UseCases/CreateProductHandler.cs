using Application.DTOs;
using Domain.Interfaces;
using Domain.Entities;

namespace Application.UseCases;

public class CreateProductHandler
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> ExecuteAsync(ProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Desc = dto.Desc,
            Price = dto.Price,
        };

        return await _repository.CreateAsync(product);
    }
}