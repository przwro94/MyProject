using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Dtos;
using MyProject.Extensions;
using MyProject.Models;

namespace MyProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetOrders()
    {
        var orders = await context.Orders.ToListAsync();
        
        if(!orders.Any())
        {
            return NotFound("No orders found.");
        }
        
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetOrder(int id)
    {
        var order = await context.Orders.FindAsync(id);
        
        if (order == null)
        {
            return NotFound($"Order with id {id} not found.");
        }
        
        return Ok(order);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrder(int id)
    {
        var order = await context.Orders.FindAsync(id);
        
        if (order == null)
        {
            return NotFound($"Order with id {id} not found.");
        }
        
        context.Orders.Remove(order);
        await context.SaveChangesAsync();
        
        return NoContent();
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateOrder(OrderCreateDto orderCreateDto)
    {
        var order = orderCreateDto.ToOrder();
        
        context.Orders.Add(order);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(CreateOrder), new { id = order.Id }, order);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateOrder(int id, OrderPutDto orderPutDto)
    {
        var order = await context.Orders.FindAsync(id);
        
        if (order == null)
        {
            return NotFound($"Order with id {id} not found.");
        }
        
        order.Name = orderPutDto.Name;
        
        context.Orders.Update(order);
        await context.SaveChangesAsync();
        
        return NoContent();
    }
    
    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchOrder(int id, OrderPatchDto orderPatchDto)
    {
        var order = await context.Orders.FindAsync(id);
        
        if (order == null)
        {
            return NotFound($"Order with id {id} not found.");
        }
        
        order.Price = orderPatchDto.Price;
        
        context.Orders.Update(order);
        await context.SaveChangesAsync();
        
        return NoContent();
    }
}