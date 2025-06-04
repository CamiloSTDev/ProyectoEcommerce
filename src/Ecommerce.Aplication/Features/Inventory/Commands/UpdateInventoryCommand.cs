
using Application.DTOs;
using MediatR;

namespace Application.Commands;

public class UpdateInventoryCommand : IRequest<InventoryDto>
{
    public int Id { get; set; }
    public int Stock { get; set; }
}