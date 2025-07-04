using Microsoft.AspNetCore.Mvc;
using MyProject.WebAPI.Extensions;
using MyProject.WebAPI.Dtos;
using MyProject.WebAPI.Models;
using MyProject.WebAPI.Services;

namespace MyProject.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(IOrderService orderService) : ControllerBase
{
    private async Task<Order?> FindOrderAsync(int id)
        => await orderService.GetOrderByIdAsync(id);

    private ActionResult NotFoundMessage(int id)
        => NotFound($"Order with id {id} not found.");

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        var orders = await orderService.GetAllOrdersAsync();

        if (!orders.Any())
            return NotFound("No orders found.");

        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await FindOrderAsync(id);
        if (order is null)
            return NotFoundMessage(id);

        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(OrderCreateDto orderCreateDto)
    {
        var order = orderCreateDto.ToOrder();

        await orderService.CreateOrderAsync(order);

        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateOrder(int id, OrderPutDto orderPutDto)
    {
        var order = await FindOrderAsync(id);
        if (order is null)
            return NotFoundMessage(id);

        order.Name = orderPutDto.Name;
        await orderService.UpdateOrderAsync(order);

        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchOrder(int id, OrderPatchDto orderPatchDto)
    {
        var order = await FindOrderAsync(id);
        if (order is null)
            return NotFoundMessage(id);

        order.Price = orderPatchDto.Price;
        await orderService.UpdateOrderAsync(order);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrder(int id)
    {
        var order = await FindOrderAsync(id);
        if (order is null)
            return NotFoundMessage(id);

        await orderService.DeleteOrderAsync(id);

        return NoContent();
    }
}