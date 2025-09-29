namespace CovfefeBucks.Core.Models.ResponseModels;

public class CoffeeOrderResponseModel
{
    public int Id { get; set; }
    public string Customer { get; set; } = string.Empty;
    public IList<Coffee> Coffee { get; set; } = [];

    public CoffeeOrder ToDomain() => new CoffeeOrder
    {
        Id = Id,
        Customer = Customer,
        Coffee = Coffee.ToList()
    };
}
