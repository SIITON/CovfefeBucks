namespace CovfefeBucks.Core.Models;

public class CoffeeOrder
{
    public int Id { get; set; }
    public string Customer { get; set; } = string.Empty;
    public IList<Coffee> Coffee { get; set; } = [];
}