namespace CovfefeBucks.Core.Models.ResponseModels;

/// <summary>
/// Database representation of a coffee order
/// </summary>
public class CoffeeOrderResponseModel
{
    public string Id { get; set; } = string.Empty;
    public string Customer { get; set; } = string.Empty;
    public IList<Coffee> Coffee { get; set; } = [];

    public CoffeeOrder ToDomain() => new()
    {
        Id = Guid.TryParse(Id, out var g) ? g : Guid.NewGuid(),
        Customer = Customer,
        Coffee = Coffee
    };
}
