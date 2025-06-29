using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
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
    public async Task<ActionResult> CreateOrder(Order order)
    {
        context.Orders.Add(order);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(CreateOrder), new { id = order.Id }, order);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateOrder(int id, Order order)
    {
        if (id != order.Id)
        {
            return BadRequest("Order ID mismatch.");
        }
        
        var existingOrder = await context.Orders.FindAsync(id);
        
        if (existingOrder == null)
        {
            return NotFound($"Order with id {id} not found.");
        }
        
        existingOrder.Name = order.Name;
        
        context.Orders.Update(existingOrder);
        await context.SaveChangesAsync();
        
        return NoContent();
    }
    
    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchOrder(int id, Order order)
    {
        if (id != order.Id)
        {
            return BadRequest("Order ID mismatch.");
        }
        
        var existingOrder = await context.Orders.FindAsync(id);
        
        if (existingOrder == null)
        {
            return NotFound($"Order with id {id} not found.");
        }
        
        existingOrder.Name = order.Name;
        
        context.Orders.Update(existingOrder);
        await context.SaveChangesAsync();
        
        return NoContent();
    }
}