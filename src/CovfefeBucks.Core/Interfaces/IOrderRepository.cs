using CovfefeBucks.Core.Models;

namespace CovfefeBucks.Core.Interfaces;

public interface IOrderRepository
{
    void Add(CoffeeOrder order);
    CoffeeOrder Get(int id);
    IEnumerable<CoffeeOrder> GetAll();
}