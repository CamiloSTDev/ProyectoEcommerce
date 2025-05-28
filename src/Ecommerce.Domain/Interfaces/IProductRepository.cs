using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product> CreateAsync(Product product);
}