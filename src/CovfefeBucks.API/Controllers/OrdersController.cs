using CovfefeBucks.Application.Services;
using CovfefeBucks.Core.Models.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace CovfefeBucks.API.Controllers;

[Route("api/[controller]")] // api/orders
[ApiController]
public class OrdersController(IOrderService order) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ListOrders()
    {
        var result = await Task.FromResult(order.GetAll());
        return Ok(result);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetOrder(int id)
    {
        var result = await Task.FromResult(order.Get(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CoffeeOrderDto newOrder)
    {
        await Task.Run(() => order.Add(newOrder));
        return CreatedAtAction(nameof(GetOrder), new { id = newOrder.Id }, newOrder);
    }
}
