
using Application.DTOs;
using MediatR;

namespace Application.Queries;

public class GetByIdInventoryQuery : IRequest<InventoryDto>
{
    public int Id { get; set; }

}