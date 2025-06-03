
namespace Domain.Entities;

public class Inventory
{
    public int Id { get; set; }
    public int Stock { get; set; }
    public int MinStock { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}