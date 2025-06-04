
using Application.DTOs;
using MediatR;

namespace Application.Commands;

public class GetByIdInventoryCommand : IRequest<InventoryDto>
{
    public int Id { get; set; }

}