using Application.DTOs;
using MediatR;

namespace Application.Commands;

public class CreateProductCommand : IRequest<ProductDto>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}