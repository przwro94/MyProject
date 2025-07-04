using MyProject.WebAPI.Models;

namespace MyProject.WebAPI.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
            SeedData(context);
        }
    }

    private static void SeedData(AppDbContext context)
    {
        CleanDb(context);

        var order1Items = new List<OrderItem>
        {
            new OrderItem { ProductName = "Item1", Quantity = 1, UnitPrice = 10 },
            new OrderItem { ProductName = "Item2", Quantity = 2, UnitPrice = 20 }
        };
        var order2Items = new List<OrderItem>
        {
            new OrderItem { ProductName = "Item3", Quantity = 3, UnitPrice = 30 },
            new OrderItem { ProductName = "Item4", Quantity = 4, UnitPrice = 40 }
        };

        var order1 = new Order
        {
            Name = "Order1",
            Description = "First Order",
            Items = order1Items,
            Price = order1Items.Sum(i => i.Quantity * i.UnitPrice)
        };
        
        var order2 = new Order
        {
            Name = "Order2",
            Description = "Second Order",
            Items = order2Items,
            Price = order2Items.Sum(i => i.Quantity * i.UnitPrice)
        };

        context.Orders.AddRange(order1, order2);
        context.SaveChanges();
    }

    private static void CleanDb(AppDbContext context)
    {
        if(context.OrderItems.Any())
        {
            context.OrderItems.RemoveRange(context.OrderItems);
            context.SaveChanges();
        }

        if(context.Orders.Any())
        {
            context.Orders.RemoveRange(context.Orders);
            context.SaveChanges();
        }
    }
}