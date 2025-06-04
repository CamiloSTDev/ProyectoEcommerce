namespace Application.DTOs;

public class InventoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string ProductName { get; set; }
}