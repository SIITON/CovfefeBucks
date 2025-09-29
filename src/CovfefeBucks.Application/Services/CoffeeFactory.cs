using CovfefeBucks.Core.Models;

namespace CovfefeBucks.Application.Services;

public class CoffeeFactory : ICoffeeFactory
{
    public Coffee Create(string type, string size, string milkType = "")
    {
        CoffeeSize coffeeSize = size.ToLower() switch
        {
            "small" => CoffeeSize.Small,
            "medium" => CoffeeSize.Medium,
            "large" => CoffeeSize.Large,
            _ => throw new ArgumentException($"Invalid coffee size: {size}")
        };
        return type.ToLower() switch
        {
            "espresso" => new Espresso(coffeeSize),
            "americano" => new Americano(coffeeSize),
            "cappuccino" => milkType.ToLower() switch
            {
                "whole" => new Cappuccino(coffeeSize, MilkType.Whole),
                "skim" => new Cappuccino(coffeeSize, MilkType.Skim),
                "soy" => new Cappuccino(coffeeSize, MilkType.Soy),
                "almond" => new Cappuccino(coffeeSize, MilkType.Almond),
                "oat" => new Cappuccino(coffeeSize, MilkType.Oat),
                _ => throw new ArgumentException($"Invalid milk type: {milkType} for cappuccino")
            },
            _ => throw new ArgumentException($"Invalid coffee type: {type}")
        };
    }
}

public interface ICoffeeFactory
{
    Coffee Create(string type, string size, string milkType = "");
}