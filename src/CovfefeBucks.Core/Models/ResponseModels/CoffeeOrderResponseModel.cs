namespace CovfefeBucks.Core.Models.ResponseModels;

/// <summary>
/// Database representation of a coffee order
/// </summary>
public class CoffeeOrderResponseModel
{
    public int Id { get; set; }
    public string Customer { get; set; } = string.Empty;
    public IList<Coffee> Coffee { get; set; } = [];

    public CoffeeOrder ToDomain() => new()
    {
        Id = Id,
        Customer = Customer,
        Coffee = Coffee
    };
}
