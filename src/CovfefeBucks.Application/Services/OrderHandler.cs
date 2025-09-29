using CovfefeBucks.Core.Interfaces;
using CovfefeBucks.Core.Models;
using CovfefeBucks.Core.Models.ApiModels;

namespace CovfefeBucks.Application.Services;

public class OrderHandler(IOrderRepository repository, ICoffeeFactory coffee, IMapper<Coffee, CoffeeApiModel> mapper) : IOrderService
{
    public OrderApiModel Get(int id)
    {
        //var order = repository.Get(id);
        //return mapper.Map(order.Coffee);
        return new OrderApiModel();
    }

    public IEnumerable<OrderApiModel> GetAll()
    {
        var orders =repository.GetAll();
        return mapper.MapEach();
    }

    public void Add(CoffeeOrderDto order)
    {
        var coffeeList = order.Coffee.Select(coffeeOrder => coffee.Create(coffeeOrder.Type, coffeeOrder.Size))
            .ToList();
        repository.Add(new CoffeeOrder()
        {
            Coffee = coffeeList,
        });
    }
}

public interface IOrderService
{
    OrderApiModel Get(int id);
    IEnumerable<OrderApiModel> GetAll();
    void Add(CoffeeOrderDto order);
}