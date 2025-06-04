using Application.Interfaces;
using Domain.Entities;

namespace Application.Handlers;

public class GetAllInventoryHandler
{
    private readonly IInventoryRepository _repository;

    public GetAllInventoryHandler(IInventoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Inventory>> GetAllAsync()
    {
        return await _repository.GetAllInventoryAsync();
    }
}
