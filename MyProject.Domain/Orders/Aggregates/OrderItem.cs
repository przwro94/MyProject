using MyProject.Domain.Orders.ValueObjects;

namespace MyProject.Domain.Orders.Aggregates;

public class OrderItem
{
    public int Id { get; private set; }
    public string ProductName { get; private set; }
    public int Quantity { get; private set; }
    public Money UnitPrice { get; private set; }

    public int OrderId { get; private set; }
    public Order Order { get; private set; }

    protected OrderItem() { }

    public OrderItem(string productName, int quantity, Money unitPrice)
    {
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));
    }
}