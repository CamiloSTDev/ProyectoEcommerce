using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Desc { get; set; } = "";
    public decimal Price { get; set; }

    [JsonIgnore]
    public Inventory Inventory { get; set; }

}