using Domain.Entities;

namespace Application.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product> CreateAsync(Product product);
}