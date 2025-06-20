namespace Application.DTOs;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Desc { get; set; } = "";
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string CategoryName { get; set; }
}