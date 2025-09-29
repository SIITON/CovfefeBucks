namespace CovfefeBucks.Core.Models;

/// <summary>
/// Represents a coffee order made by a customer
/// </summary>
public class CoffeeOrder
{
    public Guid Id { get; init; } = Guid.NewGuid(); // Ensure there is always an id
    public string Customer { get; set; } = string.Empty;
    public IList<Coffee> Coffee { get; set; } = [];
}