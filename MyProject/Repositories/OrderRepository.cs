using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;

namespace MyProject.Repositories;

public class OrderRepository(AppDbContext context) : IOrderRepository
{
    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        => await context.Orders.ToListAsync();
    
    public async Task<Order?> GetOrderByIdAsync(int id)
        => await context.Orders.FindAsync(id);

    public Task CreateOrderAsync(Order order)
    {
        context.Orders.Add(order);
        return Task.CompletedTask;
    }

    public Task UpdateOrderAsync(Order order)
    {
        context.Orders.Update(order);
        return Task.CompletedTask;
    }

    public async Task DeleteOrderAsync(int id)
    {
        var order = await context.Orders.FindAsync(id);
        
        if (order != null)
        {
            context.Orders.Remove(order);
        }
    }

    public async Task<bool> SaveChangesAsync()
        => await context.SaveChangesAsync() >= 0;
}