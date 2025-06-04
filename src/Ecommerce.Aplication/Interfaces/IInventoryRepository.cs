
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces;

public interface IInventoryRepository
{
    Task<Inventory> CreateInventoryAsync(Inventory inventory);
    Task<InventoryDto> UpdateInventoryAsync(int id, int stock);
    Task<InventoryDto> GetInventoryByIdAsync(int id);
    Task<List<Inventory>> GetAllInventoryAsync();
}