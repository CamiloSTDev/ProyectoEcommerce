using Application.DTOs;
using MediatR;

namespace Application.Commands;

public class CreateProductCommand : IRequest<ProductDto>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string CategoryName { get; set; }

}