using CovfefeBucks.Core.Interfaces;
using CovfefeBucks.Core.Models;
using CovfefeBucks.Core.Models.ApiModels;

namespace CovfefeBucks.Application.Services;

public class OrderHandler(IOrderRepository repository, 
    ICoffeeFactory coffee, 
    IMapper<Coffee, CoffeeApiModel> mapper) : IOrderService
{
    public async Task<OrderApiModel> Get(string id)
    {
        // Validate the id, ensure it is a valid guid
        var customerId = Guid.TryParse(id, out var g) 
            ? g 
            : throw new ArgumentException("Not a valid guid");
        // Get the customer order
        var order = await repository.Get(customerId);
        return new OrderApiModel
        {
            Id = order.Id.ToString(),
            Customer = order.Customer,
            Coffee = order.Coffee.Select(mapper.Map) // Map each Coffee to CoffeeApiModel
        };
    }

    public async Task<IEnumerable<OrderApiModel>> GetAll()
    {
        var orders = await repository.GetAll();
        // Multiple customers with different coffee orders
        return orders.Select(coffeeOrder => new OrderApiModel()
        {
            Id = coffeeOrder.Id.ToString(),
            Customer = coffeeOrder.Customer,
            // We use our mapper to map from Coffee to CoffeeApiModel
            Coffee = coffeeOrder.Coffee.Select(mapper.Map).ToList()
        });
    }

    public async Task Add(CoffeeOrderDto order)
    {
        // Create the coffee according to the order details
        var coffeeList = order.CoffeeDetails.Select(d =>
                coffee.Create(d.Type, d.Size))
            .ToList();
        // Add the new order to the repository, the id is populated automatically in CoffeeOrder
        await repository.Add(new CoffeeOrder()
        {
            Customer = order.Customer,
            Coffee = coffeeList,
        });
    }
}

public interface IOrderService
{
    Task<OrderApiModel> Get(string id);
    Task<IEnumerable<OrderApiModel>> GetAll();
    Task Add(CoffeeOrderDto order);
}