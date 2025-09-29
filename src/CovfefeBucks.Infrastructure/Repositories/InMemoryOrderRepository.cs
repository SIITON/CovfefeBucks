using System.Collections.Concurrent;
using CovfefeBucks.Core.Interfaces;
using CovfefeBucks.Core.Models;
using CovfefeBucks.Core.Models.ResponseModels;

namespace CovfefeBucks.Infrastructure.Repositories;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly ConcurrentDictionary<int, CoffeeOrderResponseModel> _orders = new();
    public void Add(CoffeeOrder order)
    {
        var orderToSave = ToResponseModel(order);
        _orders[orderToSave.Id] = orderToSave;
    }

    public CoffeeOrder Get(int id)
    {
        return _orders[id].ToDomain();
    }

    public IEnumerable<CoffeeOrder> GetAll()
    {
        return _orders.Values.Select(o => o.ToDomain()).ToList();
    }
    
    internal static CoffeeOrderResponseModel ToResponseModel(CoffeeOrder order) => new()
    {
        Id = order.Id,
        Customer = order.Customer,
        Coffee = order.Coffee.ToList()
    };
}