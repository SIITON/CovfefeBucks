namespace CovfefeBucks.Core.Models;

public abstract class Coffee
{
    public string Name { get; set; } = string.Empty;
    public string BeanType { get; set; } = "Arabica";
    public decimal Price { get; set; }
    public CoffeeSize Size { get; set; } = CoffeeSize.Medium;
    public bool HasMilk { get; set; } = false;
    public MilkType? MilkType { get; set; } = null;
}
public enum CoffeeSize
{
    Small,
    Medium,
    Large
}

public enum MilkType
{
    Whole,
    Skim,
    Soy,
    Almond,
    Oat
}

public class Espresso : Coffee
{
    public Espresso(CoffeeSize size)
    {
        Name = "Espresso";
        BeanType = "Arabica";
        Price = 2.50m;
        Size = size;
        HasMilk = false;
        MilkType = null;
    }
}

public class Americano : Coffee
{
    public Americano(CoffeeSize size)
    {
        Name = "Americano";
        BeanType = "Robusta";
        Price = 3.00m;
        Size = size; 
        HasMilk = false;
    }
}

public class Cappuccino : Coffee
{
    public Cappuccino(CoffeeSize size, MilkType milkType)
    {
        Name = "Cappuccino";
        BeanType = "Liberica";
        HasMilk = true;
        MilkType = milkType;
        Size = size;
    }
}