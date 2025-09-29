using System.Collections.Concurrent;
using CovfefeBucks.Core.Interfaces;
using CovfefeBucks.Core.Models;
using CovfefeBucks.Infrastructure.ResponseModels;

namespace CovfefeBucks.Infrastructure.Repositories;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly ConcurrentDictionary<string, CoffeeOrderResponseModel> _orders = new();
    public Task Add(CoffeeOrder order)
    {
        var orderToSave = ToResponseModel(order);
        _orders[orderToSave.Id] = orderToSave;
        return Task.CompletedTask;
    }

    public Task<CoffeeOrder> Get(Guid id)
    {
        return Task.FromResult(_orders[id.ToString()].ToDomain());
    }

    public Task<IEnumerable<CoffeeOrder>> GetAll()
    {
        var orders = _orders.Values.Select(o => o.ToDomain()).ToList();
        return Task.FromResult<IEnumerable<CoffeeOrder>>(orders);
    }
    
    internal static CoffeeOrderResponseModel ToResponseModel(CoffeeOrder order) => new()
    {
        Id = order.Id.ToString(),
        Customer = order.Customer,
        Coffee = order.Coffee.ToList()
    };
}