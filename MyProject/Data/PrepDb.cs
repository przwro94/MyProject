using MyProject.Models;

namespace MyProject.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            SeedData(context);
        }
    }

    private static void SeedData(AppDbContext context)
    {
        if (!context.Orders.Any())
        {
            context.Orders.AddRange(
                new Order { Name = "Order1" },
                new Order { Name = "Order2" }
            );
            
            context.SaveChanges();
        }
    }
}