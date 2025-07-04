namespace MyProject.WebAPI.Models;

public class Order
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}