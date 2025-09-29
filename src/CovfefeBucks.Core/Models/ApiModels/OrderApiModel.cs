namespace CovfefeBucks.Core.Models.ApiModels;

/// <summary>
/// Output model for a coffee order
/// </summary>
public class OrderApiModel
{
    public string Id { get; set; }
    public string Customer { get; set; } = string.Empty;
    public IEnumerable<CoffeeApiModel> Coffee { get; set; } = [];
}
public class CoffeeApiModel
{
    public string Name { get; set; } = string.Empty;
    public string BeanType { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Size { get; set; } = string.Empty;
    public bool HasMilk { get; set; } = false;
    public string MilkType { get; set; } = string.Empty;
}

/// <summary>
/// Input model for creating a coffee order,
/// notice that it does not contain an id.
/// </summary>
public class CoffeeOrderDto
{
    public string Customer { get; set; } = string.Empty;
    public IList<CoffeeOrderDetailsDto> CoffeeDetails { get; set; } = [];
}

public class CoffeeOrderDetailsDto
{
    public string Type { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
}
