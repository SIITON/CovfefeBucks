using CovfefeBucks.Core.Interfaces;
using CovfefeBucks.Core.Models;
using CovfefeBucks.Core.Models.ApiModels;

namespace CovfefeBucks.Application.Mappers;

public class CoffeeMapper : IMapper<Coffee, CoffeeApiModel>
{
    public CoffeeApiModel Map(Coffee src)
    {
        return new CoffeeApiModel
        {
            Name = src.Name,
            BeanType = src.BeanType,
            Price = src.Price,
            Size = src.Size.ToString(),
            HasMilk = src.HasMilk,
            MilkType = src.MilkType?.ToString() ?? "None"
        };
    }

    public IEnumerable<CoffeeApiModel> MapEach(IEnumerable<Coffee> src)
    {
        return src.Select(Map);
    }
}