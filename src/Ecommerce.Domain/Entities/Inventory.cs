using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Inventory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid ProductId { get; set; }

    [JsonIgnore]
    public Product Product { get; set; }
}