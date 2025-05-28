using Domain.Interfaces;
using Domain.Entities;

namespace Application.UseCases;

public class GetAllProductsHandler
{
    private readonly IProductRepository _repository;

    public GetAllProductsHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
