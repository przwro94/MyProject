using MyProject.Domain.Orders.ValueObjects;

namespace MyProject.Domain.Orders.Aggregates;

public class Order
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Money Price { get; private set; }

    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    protected Order() { } // For EF

    public Order(string name, string description, Money price)
    {
        Name = name;
        Description = description;
        Price = price ?? throw new ArgumentNullException(nameof(price));
    }
}