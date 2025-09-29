using CovfefeBucks.Core.Models;

namespace CovfefeBucks.Core.Interfaces;

public interface IOrderRepository
{
    /// <summary>
    /// Adds a new order to the repository
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    Task Add(CoffeeOrder order);

    /// <summary>
    /// Fetches an order by its unique identifier
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<CoffeeOrder> Get(int id);

    /// <summary>
    /// Fetches all orders from the repository
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<CoffeeOrder>> GetAll();
}