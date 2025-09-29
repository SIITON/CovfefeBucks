namespace CovfefeBucks.Core.Models.ApiModels;

// output
public class OrderApiModel
{
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

// input
public class CoffeeOrderDto
{
    public int Id { get; set; }
    public string Customer { get; set; } = string.Empty;
    public IList<CoffeeOrderDetailsDto> Coffee { get; set; } = [];
}

public class CoffeeOrderDetailsDto
{
    public string Type { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
}
