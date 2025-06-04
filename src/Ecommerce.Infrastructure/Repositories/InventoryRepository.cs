
using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly AppDbContext _context;

    public InventoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Inventory> CreateInventoryAsync(Inventory inventory)
    {
        _context.Inventories.Add(inventory);
        await _context.SaveChangesAsync();

        return inventory;
    }

    public async Task<InventoryDto> UpdateInventoryAsync(int id, int stock)
    {
        var inventory = await _context.Inventories.Include(inv => inv.Product)
            .FirstOrDefaultAsync(inv => inv.Id == id);

        inventory.Stock = stock;
        inventory.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();


        return new InventoryDto
        {
            Id = inventory.Id,
            Name = inventory.Name,
            Stock = inventory.Stock,
            UpdatedAt = inventory.UpdatedAt,
            ProductName = inventory.Product?.Name,
        };
    }

    public async Task<InventoryDto> GetInventoryByIdAsync(int id)
    {
        var i = await _context.Inventories.Include(inv => inv.Product)
            .FirstOrDefaultAsync(inv => inv.Id == id);

        return new InventoryDto
        {
            Id = i.Id,
            Name = i.Name,
            Stock = i.Stock,
            UpdatedAt = i.UpdatedAt,
            ProductName = i.Product?.Name ?? "Producto no asignado",
        };
    }

    public async Task<List<Inventory>> GetAllInventoryAsync()
    {
        return await _context.Inventories.ToListAsync();
    }
}