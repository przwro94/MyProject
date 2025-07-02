using MyProject.Models;
using MyProject.Repositories;

namespace MyProject.Services;

public class OrderService(IOrderRepository repo) : IOrderService
{
    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await repo.GetAllOrdersAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        return await repo.GetOrderByIdAsync(id);
    }

    public async Task<bool> CreateOrderAsync(Order order)
    {
        await repo.CreateOrderAsync(order);
        return await repo.SaveChangesAsync();
    }

    public async Task<bool> UpdateOrderAsync(Order order)
    {
        await repo.UpdateOrderAsync(order);
        return await repo.SaveChangesAsync();
    }

    public async Task<bool> DeleteOrderAsync(int id)
    {
        await repo.DeleteOrderAsync(id);
        return await repo.SaveChangesAsync();
    }
}